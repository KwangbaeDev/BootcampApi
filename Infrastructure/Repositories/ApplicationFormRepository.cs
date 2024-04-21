﻿using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.ApplicationFormModels;
using Core.Requests.CustomerModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ApplicationFormRepository : IApplicationFormRepository
{
    private readonly BootcampContext _context;

    public ApplicationFormRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<ApplicationFormDTO> CreateApplicationForm(CreateApplicationFormModel model)
    {
        var applicationForm = model.Adapt<ApplicationForm>();

        var existingCustomer = await _context.Customers
                                             .FirstOrDefaultAsync(c => c.DocumentNumber == model.DocumentNumber);

        if (existingCustomer != null)
        {
            applicationForm.Customer = existingCustomer;
        }
        else
        {
            var newCustomer = model.Adapt<Customer>();

            var bankDefault = await _context.Banks.FirstOrDefaultAsync(b => b.Name == "Banco Continental");
            if (bankDefault == null) 
            {
                throw new Exception("There is no default bank");
            }
            newCustomer.BankId = bankDefault.Id;

            var newCustomerId = _context.Customers.Max(c => c.Id) + 1;
            newCustomer.Id = newCustomerId;

            _context.Customers.Add(newCustomer);
            //await _context.SaveChangesAsync();

            applicationForm.CustomerId = newCustomer.Id;
        }

        _context.ApplicationForms.Add(applicationForm);

        await _context.SaveChangesAsync();

        var createApplicationForm = await _context.ApplicationForms
            .Include(af => af.Customer)
            .Include(af => af.Currency)
            .Include(af => af.Product)
            .FirstOrDefaultAsync(af => af.Id == applicationForm.Id);

        return createApplicationForm.Adapt<ApplicationFormDTO>();
    }
}