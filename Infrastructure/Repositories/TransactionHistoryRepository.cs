using Core.Constants;
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
        var transfers = _context.Transfers
                                .Where(t => filter.Concept == TransactionHistoryConcept.All ||
                                filter.Concept == TransactionHistoryConcept.Transfers)
                                .ToList();

        var paymentServices = _context.PaymentServices
                                      .Where(ps => filter.Concept == TransactionHistoryConcept.All ||
                                      filter.Concept == TransactionHistoryConcept.PaymentsService)
                                      .ToList();

        var deposits = _context.Deposits
                               .Where(d => filter.Concept == TransactionHistoryConcept.All ||
                               filter.Concept == TransactionHistoryConcept.Deposits)
                               .ToList();

        var extractions = _context.Extractions
                                  .Where(e => filter.Concept == TransactionHistoryConcept.All ||
                                  filter.Concept == TransactionHistoryConcept.Extractions)
                                  .ToList();

        List<TransactionHistoryDTO> transactions = new List<TransactionHistoryDTO>();

        transfers.ForEach(t => {
            transactions.Add(new TransactionHistoryDTO()
            {
                Id = t.Id,
                Description = "Transfer",
                Amount = t.Amount,
                TransactionDateTime = t.TransferredDateTime,
                Concept = t.Concept,
                CurrencyId = t.CurrencyId,
                AccountId = t.OriginAccountId
            });
        });

        paymentServices.ForEach(ps => {
            transactions.Add(new TransactionHistoryDTO()
            {
                Id = ps.Id,
                Description = "Payment Service",
                Amount = ps.Amount,
                TransactionDateTime = ps.PaymentServiceDateTime,
                Concept = ps.Concept,
                CurrencyId = null,
                AccountId = ps.AccountId
            });
        });

        deposits.ForEach(d => {
            transactions.Add(new TransactionHistoryDTO()
            {
                Id = d.Id,
                Description = "Deposit",
                Amount = d.Amount,
                TransactionDateTime = d.DepositDateTime,
                Concept = string.Empty,
                CurrencyId = null,
                AccountId = d.AccountId
            });
        });

        extractions.ForEach(e => {
            transactions.Add(new TransactionHistoryDTO()
            {
                Id = e.Id,
                Description = "Extraction",
                Amount = e.Amount,
                TransactionDateTime = e.ExtractionDateTime,
                Concept = string.Empty,
                CurrencyId = null,
                AccountId = e.AccountId
            });
        });

        var result = transactions
                        .Where(t => t.AccountId == filter.AccountId &&
                        (filter.Month == null && filter.Year == null ||
                        t.TransactionDateTime.Month == filter.Month && t.TransactionDateTime.Year == filter.Year) &&
                        (filter.DateFrom == null && filter.DateTo == null ||
                        t.TransactionDateTime >= filter.DateFrom && t.TransactionDateTime <= filter.DateTo))
                        .ToList();
        return result;
    }
}
