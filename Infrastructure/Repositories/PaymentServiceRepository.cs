using Core.Entities;
using Core.Exceptions;
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

        var account = await _context.Accounts
                                    .Include(a => a.Currency)
                                    .Include(a => a.Customer)
                                    .ThenInclude(c => c.Bank)
                                    .Include(a => a.CurrentAccount)
                                    .FirstOrDefaultAsync(a => a.Id == model.AccountId);
        if (account == null)
        {
            throw new NotFoundException($"Account with id: {model.AccountId} doest not exist");
        }

        var service = await _context.Services
                                    .FirstOrDefaultAsync(a => a.Id == model.ServiceId);
        if (service == null)
        {
            throw new NotFoundException($"Service with id: {model.ServiceId} doest not exist");
        }

        account.Balance = account.Balance - model.Amount;
        _context.Accounts.Update(account);

        _context.PaymentServices.Add(paymentService);

        await _context.SaveChangesAsync();

        var createPaymentService = await _context.PaymentServices
                                           .FirstOrDefaultAsync(t => t.Id == paymentService.Id);
        return createPaymentService.Adapt<PaymentServiceDTO>();
    }
}
