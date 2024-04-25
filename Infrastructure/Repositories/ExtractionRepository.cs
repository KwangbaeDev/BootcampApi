using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.ExtractionModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ExtractionRepository : IExtractionRepository
{
    private readonly BootcampContext _context;

    public ExtractionRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<ExtractionDTO> Extracting(CreateExtractionModel model)
    {
        var extraction = model.Adapt<Extraction>();

        var account = await _context.Accounts
                                      .Include(a => a.Currency)
                                      .Include(a => a.Customer)
                                      .ThenInclude(c => c.Bank)
                                      .Include(a => a.CurrentAccount)
                                      .FirstOrDefaultAsync(a => a.Id == model.AccountId);

        if (account == null)
        {
            throw new Exception("Account ID doesn't exist.");
        }

        if (account.CurrentAccount != null && model.Amount > account.CurrentAccount.OperationalLimit)
        {
            throw new Exception("The operation exceeds the operational limit.");
        }

        var totalAmountOperationsTransfers = _context.Transfers
                                                 .Where(t => t.OriginAccountId == account.Id &&
                                                 t.TransferredDateTime.Month == DateTime.Now.Month)
                                                 .Sum(t => t.Amount);

        var totalAmountOperationsDeposits = _context.Deposits
                                                 .Where(d => d.AccountId == account.Id &&
                                                 d.DepositDateTime.Month == DateTime.Now.Month)
                                                 .Sum(d => d.Amount);

        var totalAmountOperationsExtractions = _context.Extractions
                                                 .Where(e => e.AccountId == account.Id &&
                                                 e.ExtractionDateTime.Month == DateTime.Now.Month)
                                                 .Sum(e => e.Amount);

        var totalAmountOperations = totalAmountOperationsTransfers + totalAmountOperationsDeposits + totalAmountOperationsExtractions;

        if ((model.Amount + totalAmountOperations) > account.CurrentAccount!.OperationalLimit)
        {
            throw new Exception("Exceeded the operational limit.");
        }

        account.Balance = account.Balance - model.Amount;
        _context.Accounts.Update(account);

        _context.Extractions.Add(extraction);

        await _context.SaveChangesAsync();

        var createExtraction = await _context.Extractions
                                           .FirstOrDefaultAsync(e => e.Id == extraction.Id);

        return createExtraction.Adapt<ExtractionDTO>();
    }
}
