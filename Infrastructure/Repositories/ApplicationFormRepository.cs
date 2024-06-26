﻿using Core.Constants;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.ApplicationFormModels;
using Core.Requests.CustomerModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;

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

            var bankDefault = await _context.Banks
                                            .FirstOrDefaultAsync(b => b.Name == "Banco Continental");
            if (bankDefault == null) 
            {
                throw new NotFoundException("There is no default bank");
            }
            newCustomer.BankId = bankDefault.Id;

            var newCustomerId = _context.Customers.Max(c => c.Id) + 1;
            newCustomer.Id = newCustomerId;

            _context.Customers.Add(newCustomer);

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



    public async Task<ApplicationFormDTO> Update(UpdateApplicationFormModel model)
    {
        var applicationForm = await _context.ApplicationForms
                                            .Include(af => af.Customer)
                                            .Include(af => af.Currency)
                                            .Include(af => af.Product)
                                            .FirstOrDefaultAsync(af => af.Id == model.Id);
        if (applicationForm == null)
        {
            throw new NotFoundException($"ApplicationForm with id: {model.Id} doest not exist");
        }

        if (applicationForm.RequestStatus != RequestStatus.Pending)
        {
            throw new NotFoundException($"The form has already been {(applicationForm.RequestStatus == RequestStatus.Approved 
                                ? "approved" 
                                : "rejected")}");
        }

        applicationForm.ApprovalDate = model.RequestStatus == RequestStatus.Approved ? DateTime.Now : null;
        applicationForm.RejectionDate = model.RequestStatus == RequestStatus.Rejected ? DateTime.Now : null;
        applicationForm.RequestStatus = model.RequestStatus;

        _context.ApplicationForms.Update(applicationForm);

        await _context.SaveChangesAsync();

        return applicationForm.Adapt<ApplicationFormDTO>(); ;
    }
}
