﻿using Core.Constants;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.AccountModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly BootcampContext _context;

    public AccountRepository(BootcampContext context)
    {
        _context = context;
    }


    public async Task<AccountDTO> Add(CreateAccountModel model)
    {
        var account = model.Adapt<Account>();

        var currency = await _context.Currencies
                                     .FirstOrDefaultAsync(c =>c.Id == model.CurrencyId);
        if (currency == null)
        {
            throw new NotFoundException($"Currency with id: {model.CurrencyId} doest not exist");
        }

        var customer = await _context.Customers
                                     .FirstOrDefaultAsync(c =>c.Id == model.CustomerId);
        if (customer == null)
        {
            throw new NotFoundException($"Customer with id: {model.CustomerId} doest not exist");
        }

        if (account.Type == AccountType.Saving)
        {
            account.SavingAccount = model.CreateSavingAccount.Adapt<SavingAccount>();
        }

        if (account.Type == AccountType.Current)
        {
            account.CurrentAccount = model.CreateCurrentAccount.Adapt<CurrentAccount>();
        }

        _context.Accounts.Add(account);

        await _context.SaveChangesAsync();

        var createdAccount = await _context.Accounts
                                            .Include(a => a.Currency)
                                            .Include(a => a.Customer)
                                            .Include(a => a.SavingAccount)
                                            .Include(a => a.CurrentAccount)
                                            .FirstOrDefaultAsync(a =>a.Id == account.Id);
        return createdAccount.Adapt<AccountDTO>();
    }



    public async Task<bool> Delete(int id)
    {
        var account = await _context.Accounts
                                    .FindAsync(id);
        if (account == null)
        {
            throw new NotFoundException($"Account with id: {id} doest not exist");
        }

        account.IsDeleted = IsDeleteStatus.True;

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }



    public async Task<AccountDTO> GetById(int id)
    {
        var account = await _context.Accounts
                                    .Include(a => a.Currency)
                                    .Include(a => a.Customer)
                                    .Include(a => a.SavingAccount)
                                    .Include(a => a.CurrentAccount)
                                    .FirstOrDefaultAsync(a =>a.Id == id);
        if (account == null || account.IsDeleted == IsDeleteStatus.True)
        {
            throw new NotFoundException($"Account with id: {id} doest not exist");
        }

        var accountDTO = account.Adapt<AccountDTO>();
        return accountDTO;
    }



    public async Task<List<AccountDTO>> GetFiltered(FilterAccountModel filter)
    {
        var querry = _context.Accounts
            .Include(c => c.Currency)
            .AsQueryable();

        if (filter.Number is not null)
            querry = querry.Where(x =>
                x.Number == filter.Number);

        if (filter.Type is not null)
            querry = querry.Where(x =>
                x.Type == filter.Type);

        if (filter.Currency is not null)
            querry = querry.Where(x =>
                x.Currency.Name == filter.Currency);

        var result = await querry.ToListAsync();
        return result.Adapt<List<AccountDTO>>();
    }



    public async Task<List<AccountDTO>> GettAll()
    {
        var account = await _context.Accounts
                                    .Where(a => a.IsDeleted != IsDeleteStatus.True)
                                    .ToListAsync();

        var accountDTO = account.Adapt<List<AccountDTO>>();
        return accountDTO;
    }



    public async Task<AccountDTO> Update(UpdateAccountModel model)
    {
        var account = await _context.Accounts
                                    .FindAsync(model.Id);
        if (account == null || account.IsDeleted == IsDeleteStatus.True)
        {
            throw new NotFoundException($"Account with id: {model.Id} doest not exist");
        }

        model.Adapt(account);

        _context.Accounts.Update(account);

        await _context.SaveChangesAsync();

        var accountDTO = account.Adapt<AccountDTO>();
        return accountDTO;
    }
}
