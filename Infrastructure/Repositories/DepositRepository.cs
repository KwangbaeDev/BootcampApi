using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.DepositModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Infrastructure.Repositories;

public class DepositRepository : IDepositRepository
{
    private readonly BootcampContext _context;

    public DepositRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<DepositDTO> Depositing(CreateDepositModel model)
    {
        var deposit = new Deposit();
        deposit.Movement = model.Adapt<Movement>();

        var account = await _context.Accounts
                                      .Include(a => a.Currency)
                                      .Include(a => a.Customer)
                                      .ThenInclude(c => c.Bank)
                                      .Include(a => a.CurrentAccount)
                                      .FirstOrDefaultAsync(a => a.Id == model.AccountId);

        if (account == null)
        {
            throw new Exception("Account ID doesn't exist.");
        }

        if (account.CurrentAccount != null && model.Amount > account.CurrentAccount.OperationalLimit)
        {
            throw new Exception("The operation exceeds the operational limit.");
        }

        account.Balance = account.Balance + model.Amount;
        _context.Accounts.Update(account);

        var newMovementId = _context.Movements.Count() == 0 ? 1 : _context.Movements.Max(c => c.Id) + 1;
        deposit.Movement.Id = newMovementId;
        deposit.Movement.Destination = account.Number;

        _context.Movements.Add(deposit.Movement);

        deposit.MovementId = newMovementId;
        _context.Deposits.Add(deposit);

        await _context.SaveChangesAsync();

        var createDeposit = await _context.Deposits
                                           .Include(ps => ps.Movement)
                                           .FirstOrDefaultAsync(t => t.Id == deposit.Id);
        createDeposit!.Movement.Account = account;

        return createDeposit.Adapt<DepositDTO>();
    }
}
