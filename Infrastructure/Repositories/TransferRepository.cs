﻿using Core.Constants;
using Core.Entities;
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
            throw new Exception("Non-existent origin account.");
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
            throw new Exception("Non-existent destination account.");
        }

        var currency = await _context.Currencies.FirstOrDefaultAsync(a => a.Id == model.CurrencyId);
        if (currency == null)
        {
            throw new Exception("Non-existent currency.");
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
            throw new Exception("OriginAccount exceeded the operational limit.");
        }

       var totalAmountOperationsDATransfers = _context.Transfers
                                                 .Where(t => t.OriginAccountId == destinationAccount.Id &&
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
            throw new Exception("DestinationAccount exceeded the operational limit.");
        }

        originAccount.Balance = originAccount.Balance - model.Amount;
        _context.Accounts.Update(originAccount);

        destinationAccount.Balance = destinationAccount.Balance + model.Amount;
        _context.Accounts.Update(destinationAccount);

        transfer.DestinationAccountId = destinationAccount.Id;
        _context.Transfers.Add(transfer);

        await _context.SaveChangesAsync();

        var createTransfer = await _context.Transfers
                                           .FirstOrDefaultAsync(t => t.Id == transfer.Id);

        return createTransfer.Adapt<TransferDTO>();
    }
}
