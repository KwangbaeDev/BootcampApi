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
        var extraction = new Extraction();
        extraction.Movement = model.Adapt<Movement>();

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

        account.Balance = account.Balance - model.Amount;
        _context.Accounts.Update(account);

        var newMovementId = _context.Movements.Count() == 0 ? 1 : _context.Movements.Max(c => c.Id) + 1; //deberia ser reponsabilidad de la BD
        extraction.Movement.Id = newMovementId; //relacionado con el de arriba
        extraction.Movement.Destination = account.Number; //quizas no sea necesario

        _context.Movements.Add(extraction.Movement); //añadir simplemente una extraccion

        extraction.MovementId = newMovementId;
        _context.Extractions.Add(extraction);

        await _context.SaveChangesAsync();

        var createExtraction = await _context.Extractions
                                           .Include(e => e.Movement)
                                           .FirstOrDefaultAsync(e => e.Id == extraction.Id);

        createExtraction!.Movement.Account = account;

        return createExtraction.Adapt<ExtractionDTO>();
    }
}
