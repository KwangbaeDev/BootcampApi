using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.PaymentServiceModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace Infrastructure.Repositories;

public class PaymentServiceRepository : IPaymentServiceRepository
{
    private readonly BootcampContext _context;

    public PaymentServiceRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<PaymentServiceDTO> ServicePayment(CreatePaymentServiceModel model)
    {
        var paymentService = model.Adapt<PaymentService>();
        paymentService.Movement = model.Adapt<Movement>();

        var accountId = await _context.Accounts
                                      .Include(a => a.Movements)
                                      .Include(a => a.Currency)
                                      .Include(a => a.Customer)
                                      .Include(a => a.CurrentAccount)
                                      .FirstOrDefaultAsync(a => a.Id == model.AccountId);

        if (accountId == null)
        {
            throw new Exception("Account ID doesn't exist.");
        }

        accountId.Balance = accountId.Balance - model.Amount;
        _context.Accounts.Update(accountId);

        var newMovementId = _context.Movements.Count() == 0 ? 1 : _context.Movements.Max(c => c.Id) + 1;
        paymentService.Movement.Id = newMovementId;

        _context.Movements.Add(paymentService.Movement);

        paymentService.MovementId = newMovementId;
        _context.PaymentServices.Add(paymentService);

        await _context.SaveChangesAsync();

        var createPaymentService = await _context.PaymentServices
                                           .Include(ps => ps.Movement)
                                           .ThenInclude(m => m.Account)
                                           .ThenInclude(a => a.Customer)
                                           .ThenInclude(c => c.Bank)
                                           .FirstOrDefaultAsync(t => t.Id == paymentService.Id);

        return createPaymentService.Adapt<PaymentServiceDTO>();
    }
}
