using Core.Constants;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.CustomerModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Timers;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly BootcampContext _context;

    public CustomerRepository(BootcampContext context)
    {
        _context = context;
    }


    public async Task<List<CustomerDTO>> GetFiltered(FilterCustomersModel filter)
    {
        var query = _context.Customers
                            .Include(c => c.Bank)
                            .AsQueryable();

        if (filter.BirthYearFrom is not null)
        {
            query = query.Where(c =>
                                c.Birth != null &&
                                c.Birth.Value.Year >= filter.BirthYearFrom);
        }


        if (filter.BirthYearTo is not null)
        {
            query = query.Where(c =>
                                c.Birth != null &&
                                c.Birth.Value.Year <= filter.BirthYearTo);
        }


        if (filter.BankId is not null)
        {
            query = query.Where(c =>
                                c.BankId == filter.BankId);
        }


        if (filter.DocumentNumber is not null)
        {
            query = query.Where(c =>
                                 c.DocumentNumber == filter.DocumentNumber);
        }


        if (filter.Mail is not null)
        {
            query = query.Where(c =>
                                c.Mail == filter.Mail);
        }


        if (filter.FullName is not null)
        {
            query = query.Where(c =>
                                c.Name + " " + c.Lastname == filter.FullName);
        }

        var result = await query.ToListAsync();
        return result.Adapt<List<CustomerDTO>>();
    }
    


    public async Task<CustomerDTO> Add(CreateCustomerModel model)
    {
        var bank = await _context.Banks
                                 .FindAsync(model.BankId);
        if (bank == null)
        {
            throw new NotFoundException($"Bank with id: {model.BankId} doest not exist");
        }

        var existingCustomer = await _context.Customers
                                     .FirstOrDefaultAsync(c => c.DocumentNumber == model.DocumentNumber &&
                                     c.BankId == model.BankId);

        if (existingCustomer != null)
        {
            throw new NotFoundException($"The customer with document number {model.DocumentNumber} " +
                                        $"is already registered in the bank {model.BankId}");
        }

        var customerToCreate = model.Adapt<Customer>();

        _context.Customers.Add(customerToCreate);

        await _context.SaveChangesAsync();

        var customerDTO = customerToCreate.Adapt<CustomerDTO>();
        return customerDTO;
    }



    public async Task<CustomerDTO> GetById(int id)
    {
        var customer = await _context.Customers
                                     .Include(c => c.Bank)
                                     .FirstOrDefaultAsync(c => c.Id == c.Id);
        if (customer == null)
        {
            throw new NotFoundException($"Customer with id: {id} doest not exist");
        }

        var customerDTO = customer.Adapt<CustomerDTO>();
        return customerDTO;
    }



    public async Task<List<CustomerDTO>> GetAll()
    {
        var customer = await _context.Customers
                                     .Include(c => c.Bank)
                                     .ToListAsync();

        var customerDTO = customer.Adapt<List<CustomerDTO>>();
        return customerDTO;
    }
    


    public async Task<CustomerDTO> Update(UpdateCustomerModel model)
    {
        var customer = await _context.Customers
                                     .Include(c => c.Bank)
                                     .FirstOrDefaultAsync(c => c.Id == model.Id);
        if (customer == null)
        {
            throw new NotFoundException($"Customer with id: {model.Id} doest not exist");
        }

        model.Adapt(customer);

        _context.Customers.Update(customer);

        await _context.SaveChangesAsync();

        var customerDTO = customer.Adapt<CustomerDTO>();
        return customerDTO;
    }



    public async Task<bool> Delete(int id)
    {
        var customer = await _context.Customers
                                     .FindAsync(id);
        if (customer == null)
        {
            throw new NotFoundException($"Bank with id: {id} doest not exist");
        }

        _context.Customers.Remove(customer);

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}