﻿using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.CreditCardModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CreditCardRepository : ICreditCardRepository
{
    private readonly BootcampContext _context;

    public CreditCardRepository(BootcampContext context)
    {
        _context = context;
    }


    public async Task<CreditCardDTO> Add(CreateCreditCardModel model)
    {
        var customer = await _context.Customers
                                     .FindAsync(model.CustomerId);
        if (customer == null)
        {
            throw new NotFoundException($"Customer with id: {model.CustomerId} doest not exist");
        }

        var currency = await _context.Currencies
                                     .FindAsync(model.CurrencyId);
        if (currency == null)
        {
            throw new NotFoundException($"Currency with id: {model.CurrencyId} doest not exist");
        }

        var creditCardToCreate = model.Adapt<CreditCard>();

        _context.CreditCards.Add(creditCardToCreate);

        await _context.SaveChangesAsync();

        var creditCardDTO = creditCardToCreate.Adapt<CreditCardDTO>();
        return creditCardDTO;
    }



    public async Task<bool> Delete(int id)
    {
        var creditCard = await _context.CreditCards
                                       .FindAsync(id);
        if (creditCard == null)
        {
            throw new NotFoundException($"CreditCard with id: {id} doest not exist");
        }

        _context.CreditCards.Remove(creditCard);

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }



    public async Task<List<CreditCardDTO>> GetAll()
    {
        var creditCard = await _context.CreditCards
                                       .ToListAsync();

        var creditCardDTO = creditCard.Adapt<List<CreditCardDTO>>();
        return creditCardDTO;
    }



    public async Task<CreditCardDTO> GetById(int id)
    {
        var creditCard = await _context.CreditCards
                                       .FindAsync(id);
        if (creditCard == null)
        {
            throw new NotFoundException($"CreditCard with id: {id} doest not exist");
        }

        var creditCardDTO = creditCard.Adapt<CreditCardDTO>();
        return creditCardDTO;
    }




    public async Task<List<CreditCardDTO>> GetFiltered(FilterCreditCardModel filter)
    {
        var query = _context.CreditCards
                            .Include(cc => cc.Customer)
                            .AsQueryable();

        if (filter.Designation is not null)
            query = query.Where(x =>
                                x.Designation == filter.Designation);

        if (filter.CustomerName is not null)
            query = query.Where(x =>
                                x.Customer.Name == filter.CustomerName);

        var result = await query.ToListAsync();      
        return result.Adapt<List<CreditCardDTO>>();
    }



    public async Task<CreditCardDTO> Update(UpdateCreditCardModel model)
    {
        var creditCard = await _context.CreditCards
                                       .FindAsync(model.Id);

        if (creditCard == null)
        {
            throw new NotFoundException($"CreditCard with id: {model.Id} doest not exist");
        }

        model.Adapt(creditCard);

        _context.CreditCards.Update(creditCard);

        await _context.SaveChangesAsync();

        var creditCardDTO = creditCard.Adapt<CreditCardDTO>();
        return creditCardDTO;
    }
}
