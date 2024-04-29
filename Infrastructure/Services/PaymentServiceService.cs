using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.PaymentServiceModels;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Infrastructure.Services;

public class PaymentServiceService : IPaymentServiceService
{
    private readonly IPaymentServiceRepository _repository;

    public PaymentServiceService(IPaymentServiceRepository repository)
    {
        _repository = repository;
    }


    public async Task<PaymentServiceDTO> ServicePayment(CreatePaymentServiceModel model)
    {
        return await _repository.ServicePayment(model);
    }
}
