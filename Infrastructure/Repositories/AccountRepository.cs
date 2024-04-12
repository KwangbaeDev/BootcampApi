using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

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
        var customer = await _context.Customers
                                     .Include(x => x.Bank)
                                     .FirstOrDefaultAsync(x => x.Id == model.CustomerId);

        if (customer is null)
        {
            throw new Exception("Customer not found");
        }

        var currency = await _context.Currencies.FindAsync(model.CurrencyId);

        if (currency is null)
        {
            throw new Exception("Currency not found");
        }

        //AccountDTO accountDTO;
        //switch (model.Type)
        //{
        //    case 0:
        //        var savingAccount = model.Adapt<SavingAccount>();
        //        _context.SavingAccounts.Add(savingAccount);
        //        await _context.SaveChangesAsync();
        //        accountDTO = new AccountDTO
        //        {
        //            Id = savingAccount.Id,
        //            Type = (AccountType)SavingType.Insight,
        //            Holder = savingAccount.HolderName,
        //            Accounts = savingAccount.Adapt<AccountDTO>()
        //        };
        //        break;
        //    case 1:
        //        var currentAccount = model.Adapt<CurrentAccount>();
        //        _context.CurrentAccounts.Add(currentAccount);
        //        await _context.SaveChangesAsync();
        //        accountDTO = new AccountDTO
        //        {
        //            Id = currentAccount.Id,
        //            Accounts = currentAccount.Adapt<AccountDTO>()
        //        };
        //        break;
        //    default:
        //        throw new Exception("Invalid account type");
        //}

        var accountToCreate = model.Adapt<Account>();

        _context.Accounts.Add(accountToCreate);

        await _context.SaveChangesAsync();

        var accountDTO = accountToCreate.Adapt<AccountDTO>();

        return accountDTO;
    }

    public async Task<bool> Delete(int id)
    {
        var account = await _context.Accounts.FindAsync(id);

        if (account is null)
        {
            throw new Exception("Account not found");
        }

        account.IsDeleted = IsDeleteStatus.True;

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<AccountDTO> GetById(int id)
    {
        var account = await _context.Accounts.FindAsync(id);

        if (account is null || account.IsDeleted == IsDeleteStatus.True)
        {
            throw new Exception("Account not found");
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

        //if (filter.Type is not null)
        //    querry = querry.Where(x =>
        //        x.Type == filter.Type);

        if (filter.Currency is not null)
            querry = querry.Where(x =>
                x.Currency.Name == filter.Currency);

        var result = await querry.ToListAsync();

        return result.Adapt<List<AccountDTO>>();
    }

    public async Task<List<AccountDTO>> GettAll()
    {
        var account = await _context.Accounts
                                    .Where(a => a.IsDeleted != IsDeleteStatus.False)
                                    .ToListAsync();

        var accountDTO = account.Adapt<List<AccountDTO>>();

        return accountDTO;
    }

    public async Task<AccountDTO> Update(UpdateAccountModel model)
    {
        var account = await _context.Accounts.FindAsync(model.Id);

        if (account is null)
        {
            throw new Exception("Account was not found");
        }

        model.Adapt(account);

        _context.Accounts.Update(account);

        await _context.SaveChangesAsync();

        var accountDTO = account.Adapt<AccountDTO>();

        return accountDTO;
    }
}
