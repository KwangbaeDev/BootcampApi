using Core.Models;
using Core.Requests.PaymentServiceModels;

namespace Core.Interfaces.Repositories;

public interface IPaymentServiceRepository
{
    Task<PaymentServiceDTO> ServicePayment(CreatePaymentServiceModel model);
}
