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
        var deposit = model.Adapt<Deposit>();

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

        var bank = await _context.Banks
                                      .FirstOrDefaultAsync(a => a.Id == model.BankId);

        if (bank == null)
        {
            throw new Exception("Bank ID doesn't exist.");
        }

        if (account.CurrentAccount != null && model.Amount > account.CurrentAccount.OperationalLimit)
        {
            throw new Exception("The operation exceeds the operational limit.");
        }

        var totalAmountOperationsTransfers = _context.Transfers
                                                 .Where(t => t.OriginAccountId == account.Id &&
                                                 t.TransferredDateTime.Month == DateTime.Now.Month)
                                                 .Sum(t => t.Amount);

        var totalAmountOperationsDeposits = _context.Deposits
                                                 .Where(d => d.AccountId == account.Id &&
                                                 d.DepositDateTime.Month == DateTime.Now.Month)
                                                 .Sum(d => d.Amount);

        var totalAmountOperationsExtractions = _context.Extractions
                                                 .Where(e => e.AccountId == account.Id &&
                                                 e.ExtractionDateTime.Month == DateTime.Now.Month)
                                                 .Sum(e => e.Amount);

        var totalAmountOperations = totalAmountOperationsTransfers + totalAmountOperationsDeposits + totalAmountOperationsExtractions;

        if ((model.Amount + totalAmountOperations) > account.CurrentAccount!.OperationalLimit)
        {
            throw new Exception("Exceeded the operational limit.");
        }

        account.Balance = account.Balance + model.Amount;
        _context.Accounts.Update(account);

        _context.Deposits.Add(deposit);

        await _context.SaveChangesAsync();

        var createDeposit = await _context.Deposits
                                           .FirstOrDefaultAsync(p => p.Id == deposit.Id);

        return createDeposit.Adapt<DepositDTO>();
    }
}
