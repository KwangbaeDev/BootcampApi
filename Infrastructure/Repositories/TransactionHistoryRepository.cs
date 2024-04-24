using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.TransactionHistoryModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repositories;

public class TransactionHistoryRepository : ITransactionHistoryRepository
{
    private readonly BootcampContext _context;

    public TransactionHistoryRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionHistoryDTO>> GetFiltered(FilterTransactionHistoryModel filter)
    {
        var query = _context.Accounts
                            .Include(a => a.Transfers)
                            .Include(a => a.PaymentServices)
                            .Include(a => a.Deposits)
                            .Include(a => a.Extractions)
                            .AsQueryable();


        if (filter.AccountNumber is not null)
            query = query.Where(x =>
                x.Number == filter.AccountNumber);



        



        var result = await query.ToListAsync();

        return result.Adapt<List<TransactionHistoryDTO>>();
    }
}
