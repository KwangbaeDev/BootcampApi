using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

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
            foreach (var customer in query)
            {
                await Console.Out.WriteLineAsync("customer: " + customer.Name);
            }
            query = query.Where(x =>
                x.BankId == filter.BankId);
        }


        if (filter.DocumentNumber is not null)
        {
            query = query.Where(x =>
                x.DocumentNumber != null &&
                x.DocumentNumber.Length <= filter.DocumentNumber);
        }

        if (filter.Mail is not null)
        {
            query = query.Where(x =>
                x.Mail != null &&
                x.Mail.Length <= filter.DocumentNumber);
        }

        if (filter.Fullname is not null)
        {
            query = query.Where(x =>
                x.DocumentNumber != null &&
                x.DocumentNumber.Length <= filter.DocumentNumber);
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
            CustomerStatus = nameof(x.CustomerStatus),
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
}