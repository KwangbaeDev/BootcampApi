using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
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
        if (Enum.IsDefined(typeof(CustomerStatus), model.CustomerStatus) == false)
        {
            throw new Exception("The CustomerStatus provided is not valid.");
        }

        var bank = await _context.Banks.FindAsync(model.BankId);
        if (bank is null)
        {
            throw new Exception("Bank not found");
        }


        var customerToCreate = new Customer
        {
            Name = model.Name,
            Lastname = model.Lastname,
            DocumentNumber = model.DocumentNumber,
            Address = model.Address,
            Mail = model.Mail,
            Phone = model.Phone,
            CustomerStatus = (CustomerStatus)model.CustomerStatus,
            Birth = model.Birth,
            BankId = model.BankId,
        };

        _context.Customers.Add(customerToCreate);

        await _context.SaveChangesAsync();

        var customerDTO = new CustomerDTO
        {
            Id = customerToCreate.Id,
            Name = customerToCreate.Name,
            Lastname = customerToCreate.Lastname,
            DocumentNumber = customerToCreate.DocumentNumber,
            Address = customerToCreate.Address,
            Mail = customerToCreate.Mail,
            Phone = customerToCreate.Phone,
            CustomerStatus = model.CustomerStatus,
            Birth = customerToCreate.Birth,
            Bank = new BankDTO()
            {
                 Id = bank.Id,
                 Name = bank.Name,
                 Phone = bank.Phone,
                 Mail = bank.Mail,
                 Address = bank.Address,
            },
        };

        return customerDTO;
    }
}