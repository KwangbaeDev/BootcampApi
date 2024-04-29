using Core.Constants;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.TransferModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

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

        var originAccount = await _context.Accounts
                                          .Include(a => a.Customer)
                                          .ThenInclude(c => c.Bank)
                                          .Include(a => a.CurrentAccount)
                                          .Include(a => a.Currency)
                                          .FirstOrDefaultAsync(a => a.Id == model.OriginAccountId);
        if (originAccount == null) 
        {
            throw new NotFoundException($"OriginAccount with id: {model.OriginAccountId} doest not exist");
        }

        var destinationAccount = await _context.Accounts
                                              .Include(a => a.Customer)
                                              .ThenInclude(c => c.Bank)
                                              .Include(a => a.CurrentAccount)
                                              .Include(a => a.Currency)
                                              .FirstOrDefaultAsync(a => 
                                              a.Number == model.AccountNumber && 
                                              a.Customer.DocumentNumber == model.DocumentNumber);
        if (destinationAccount == null)
        {
            throw new NotFoundException($"DestinationAccount with id: {destinationAccount} doest not exist");
        }

        if (model.TransferType == TransferType.AnotherBank)
        {
            if (destinationAccount.Customer.BankId != model.DenstinationBankId)
            {
                throw new NotFoundException("The destination bank does not exist.");
            }

            if (destinationAccount.Currency.Id != model.CurrencyId)
            {
                throw new NotFoundException($"Currency with id: {model.CurrencyId} doest not exist");
            }
        }
        else
        {
            if (destinationAccount.Customer.BankId != originAccount.Customer.BankId)
            {
                throw new NotFoundException("Bank accounts do not match.");
            }
        }

        if (originAccount.Type != destinationAccount.Type)
        {
            throw new NotFoundException("It has to be the same type of account.");
        }

        if (originAccount.CurrencyId != destinationAccount.CurrencyId)
        {
            throw new NotFoundException("It must be the same currency.");
        }

        if (model.Amount > originAccount.Balance)
        {
            throw new NotFoundException("The transfer amount must not be greater than the current account balance.");
        }

        if (originAccount.Status == AccountStatus.Inactive)
        {
            throw new NotFoundException("The origin account must be active.");
        }

        if (destinationAccount.Status == AccountStatus.Inactive)
        {
            throw new NotFoundException("The destination account must be active.");
        }

        if (originAccount.CurrentAccount != null && model.Amount > originAccount.CurrentAccount.OperationalLimit)
        {
            throw new NotFoundException("The operation exceeds the operational limit.");
        }

        //Valida el limite operacional de la cuenta de origen
        var totalAmountOperationsOATransfers = _context.Transfers
                                                            .Where(t => t.OriginAccountId == originAccount.Id &&
                                                            t.TransferredDateTime.Month == DateTime.Now.Month)
                                                            .Sum(t => t.Amount);

        var totalAmountOperationsOADeposits = _context.Deposits
                                                             .Where(d => d.AccountId == originAccount.Id &&
                                                             d.DepositDateTime.Month == DateTime.Now.Month)
                                                             .Sum(d => d.Amount);

        var totalAmountOperationsOAExtractions = _context.Extractions
                                                              .Where(e => e.AccountId == originAccount.Id &&
                                                              e.ExtractionDateTime.Month == DateTime.Now.Month)
                                                              .Sum(e => e.Amount);

        var totalAmountOperationsOA = totalAmountOperationsOATransfers + totalAmountOperationsOADeposits + totalAmountOperationsOAExtractions;

        if ((model.Amount + totalAmountOperationsOA) > originAccount.CurrentAccount!.OperationalLimit)
        {
            throw new NotFoundException("OriginAccount exceeded the operational limit.");
        }

       //Valida el limite operacional de la cuenta de destino
       var totalAmountOperationsDATransfers = _context.Transfers
                                                 .Where(t => t.DestinationAccountId == destinationAccount.Id &&
                                                 t.TransferredDateTime.Month == DateTime.Now.Month)
                                                 .Sum(t => t.Amount);

       var totalAmountOperationsDADeposits = _context.Deposits
                                                 .Where(d => d.AccountId == destinationAccount.Id &&
                                                 d.DepositDateTime.Month == DateTime.Now.Month)
                                                 .Sum(d => d.Amount);

       var totalAmountOperationsDAExtractions = _context.Extractions
                                                 .Where(e => e.AccountId == destinationAccount.Id &&
                                                 e.ExtractionDateTime.Month == DateTime.Now.Month)
                                                 .Sum(e => e.Amount);

       var totalAmountOperationsDA = totalAmountOperationsDATransfers + totalAmountOperationsDADeposits + totalAmountOperationsDAExtractions;

        if ((model.Amount + totalAmountOperationsDA) > destinationAccount.CurrentAccount!.OperationalLimit)
        {
            throw new NotFoundException("DestinationAccount exceeded the operational limit.");
        }

        originAccount.Balance = originAccount.Balance - model.Amount;
        _context.Accounts.Update(originAccount);

        destinationAccount.Balance = destinationAccount.Balance + model.Amount;
        _context.Accounts.Update(destinationAccount);

        transfer.DestinationAccountId = destinationAccount.Id;

        if (model.TransferType == TransferType.SameBank)
        {
            transfer.CurrencyId = destinationAccount.CurrencyId;
            transfer.DestinationBankId = destinationAccount.Customer.BankId;
        }

        _context.Transfers.Add(transfer);

        await _context.SaveChangesAsync();

        var createTransfer = await _context.Transfers
                                           .FirstOrDefaultAsync(t => t.Id == transfer.Id);
        return createTransfer.Adapt<TransferDTO>();
    }
}
