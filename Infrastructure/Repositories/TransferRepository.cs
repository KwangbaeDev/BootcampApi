using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.TransferModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TransferRepository : ITransferRepository
{
    private readonly BootcampContext _context;

    public TransferRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<TransferDTO> Transferred(CreateTransferModel model)
    {
        var transfer = model.Adapt<Transfer>();
        transfer.Movement = model.Adapt<Movement>();

        var originAccount = await _context.Accounts
                                          .Include(a => a.Customer)
                                          .ThenInclude(c => c.Bank)
                                          .Include(a => a.CurrentAccount)
                                          .Include(a => a.Currency)
                                          .FirstOrDefaultAsync(a => a.Id == model.OriginAccountId);
        if (originAccount == null) 
        {
            throw new Exception("Non-existent origin account.");
        }

        var destinationAccount = await _context.Accounts
                                              .Include(a => a.Customer)
                                              .ThenInclude(c => c.Bank)
                                              .Include(a => a.Currency)
                                              .FirstOrDefaultAsync(a => 
                                              a.Number == model.AccountNumber && 
                                              a.Customer.DocumentNumber == model.DocumentNumber);

        if (destinationAccount == null)
        {
            throw new Exception("Non-existent destination account.");
        }

        if (model.TransferType == TransferType.AnotherBank)
        {
            if (destinationAccount.Customer.BankId != model.DenstinationBankId)
            {
                throw new Exception("The destination bank does not exist.");
            }
        }
        else
        {
            if (destinationAccount.Customer.BankId != originAccount.Customer.BankId)
            {
                throw new Exception("Bank accounts do not match.");
            }
        }

        if (originAccount.Type != destinationAccount.Type)
        {
            throw new Exception("It has to be the same type of account.");
        }

        if (originAccount.CurrencyId != destinationAccount.CurrencyId)
        {
            throw new Exception("It must be the same currency.");
        }

        if (model.Amount > originAccount.Balance)
        {
            throw new Exception("The transfer amount must not be greater than the current account balance.");
        }

        if (originAccount.Status == AccountStatus.Inactive)
        {
            throw new Exception("The origin account must be active.");
        }

        if (destinationAccount.Status == AccountStatus.Inactive)
        {
            throw new Exception("The destination account must be active.");
        }

        if (originAccount.CurrentAccount != null && model.Amount > originAccount.CurrentAccount.OperationalLimit)
        {
            throw new Exception("The operation exceeds the operational limit.");
        }

        originAccount.Balance = originAccount.Balance - model.Amount;
        _context.Accounts.Update(originAccount);

        destinationAccount.Balance = destinationAccount.Balance + model.Amount;
        _context.Accounts.Update(destinationAccount);

        var newMovementId = _context.Movements.Count() == 0 ? 1 : _context.Movements.Max(c => c.Id) + 1;
        transfer.Movement.Id = newMovementId;

        _context.Movements.Add(transfer.Movement);

        transfer.DestinationAccountId = destinationAccount.Id;
        transfer.MovementId = newMovementId;
        _context.Transfers.Add(transfer);

        await _context.SaveChangesAsync();

        var createTransfer = await _context.Transfers
                                           .Include(t => t.Movement)
                                           .FirstOrDefaultAsync(t => t.Id == transfer.Id);
        createTransfer!.Movement.Account = originAccount;
        createTransfer!.OriginAccount = destinationAccount;


        return createTransfer.Adapt<TransferDTO>();
    }
}
