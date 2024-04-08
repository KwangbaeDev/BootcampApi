using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
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
            query = query.Where(x =>
                x.Birth != null &&
                x.Birth.Value.Year >= filter.BirthYearFrom);
        }


        if (filter.BirthYearTo is not null)
        {
            query = query.Where(x =>
                x.Birth != null &&
                x.Birth.Value.Year <= filter.BirthYearTo);
        }


        if (filter.BankId is not null)
        {
            query = query.Where(x =>
                x.BankId == filter.BankId);
        }


        if (filter.DocumentNumber is not null)
        {
            query = query.Where(x =>
                x.DocumentNumber == filter.DocumentNumber);
        }


        if (filter.Mail is not null)
        {
            query = query.Where(x =>
                x.Mail == filter.Mail);
        }


        if (filter.FullName is not null)
        {
            query = query.Where(x =>
                x.Name + " " + x.Lastname == filter.FullName);
        }


        var result = await query.ToListAsync();

        return result.Select(x => new CustomerDTO
        {
            Id = x.Id,
            Name = x.Name,
            Lastname = x.Lastname,
            DocumentNumber = x.DocumentNumber,
            Address = x.Address,
            Mail = x.Mail,
            Phone = x.Phone,
            CustomerStatus = (int)x.CustomerStatus,
            Birth = x.Birth,
            Bank = new BankDTO
            {
                Id = x.Bank.Id,
                Name = x.Bank.Name,
                Phone = x.Bank.Phone,
                Mail = x.Bank.Mail,
                Address = x.Bank.Address
            }
        }).ToList();
    }
    
    public async Task<CustomerDTO> Add(CreateCustomerModel model)
    {
        var bank = await _context.Banks.FindAsync(model.BankId);
        if (bank is null)
        {
            throw new Exception("Bank not found");
        }

        var customerToCreate = model.Adapt<Customer>();

        _context.Customers.Add(customerToCreate);

        await _context.SaveChangesAsync();

        var customerDTO = customerToCreate.Adapt<CustomerDTO>();

        return customerDTO;
    }

    public async Task<CustomerDTO> GetById(int id)
    {
        var banks = await _context.Banks.ToListAsync();

        var customer = await _context.Customers.FindAsync(id);

        if (customer is null) throw new Exception("Customer not found");

        var customerDTO = customer.Adapt<CustomerDTO>();

        return customerDTO;
    }

    public async Task<List<CustomerDTO>> GetAll()
    {
        var banks = await _context.Banks.ToListAsync();

        var customer = await _context.Customers.ToListAsync();

        var customerDTO = customer.Adapt<List<CustomerDTO>>();

        return customerDTO;
    }

    //public async Task<CustomerDTO> Update(UpdateCustomerModel model)
    //{
    //    var customer = await _context.Customers.FindAsync(model.Id);

    //    if (customer is null) throw new Exception("Bank was not found.");

    //    model.Adapt(customer);

    //    _context.Customers.Update(customer);

    //    await _context.SaveChangesAsync();

    //    var customerDTO = customer.Adapt<CustomerDTO>();

    //    return customerDTO;
    //}
}