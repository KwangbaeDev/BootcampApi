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

        account.Balance = account.Balance - model.Amount;
        _context.Accounts.Update(account);

        var newMovementId = _context.Movements.Count() == 0 ? 1 : _context.Movements.Max(c => c.Id) + 1;
        paymentService.Movement.Id = newMovementId;
        paymentService.Movement.Destination = account.Number;

        _context.Movements.Add(paymentService.Movement);

        paymentService.MovementId = newMovementId;
        _context.PaymentServices.Add(paymentService);

        await _context.SaveChangesAsync();

        var createPaymentService = await _context.PaymentServices
                                           .Include(ps => ps.Movement)
                                           .FirstOrDefaultAsync(t => t.Id == paymentService.Id);
        createPaymentService!.Movement.Account = account;

        return createPaymentService.Adapt<PaymentServiceDTO>();
    }
}
