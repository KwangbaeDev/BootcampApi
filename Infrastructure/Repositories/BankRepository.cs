﻿using Core.Interfaces.Repositories;
using Core.Models;
using Infrastructure.Contexts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Core.Exceptions;
using Core.Requests.BankModels;

namespace Infrastructure.Repositories;

public class BankRepository : IBankRepository
{
    private readonly BootcampContext _context;

    public BankRepository(BootcampContext context)
    {
        _context = context;
    }


    public async Task<BankDTO> Add(CreateBankModel model)
    {
        var bankToCreate = model.Adapt<Bank>();

        _context.Banks.Add(bankToCreate);

        await _context.SaveChangesAsync();

        var bankDTO = bankToCreate.Adapt<BankDTO>();
        return bankDTO;
    }



    public async Task<bool> Delete(int id)
    {
        var bank = await _context.Banks.FindAsync(id);
        if (bank == null)
        {
            throw new NotFoundException($"Bank with id: {id} doest not exist");
        }

        _context.Banks.Remove(bank);

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }



    public async Task<List<BankDTO>> GetAll()
    {
        var banks = await _context.Banks.ToListAsync();

        var banksDTO = banks.Adapt<List<BankDTO>>();
        return banksDTO;
    }

    public async Task<BankDTO> GetById(int id)
    {
        var bank = await _context.Banks.FindAsync(id);
        if (bank == null)
        {
            throw new NotFoundException($"Bank with id: {id} doest not exist");
        }

        var bankDTO = bank.Adapt<BankDTO>();
        return bankDTO;
    }



    public async Task<bool> NameIsAlreadyTaken(string name)
    {
        return await _context.Banks.AnyAsync(bank => bank.Name == name);
    }



    public async Task<BankDTO> Update(UpdateBankModel model)
    {
        var bank = await _context.Banks.FindAsync(model.Id);
        if (bank == null)
        {
            throw new NotFoundException($"Bank with id: {model.Id} doest not exist");
        }

        model.Adapt(bank);

        _context.Banks.Update(bank);

        await _context.SaveChangesAsync();

        var bankDTO = bank.Adapt<BankDTO>();
        return bankDTO;
    }
}
