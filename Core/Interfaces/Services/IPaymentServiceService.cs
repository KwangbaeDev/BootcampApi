using Core.Models;
using Core.Requests.PaymentServiceModels;

namespace Core.Interfaces.Services;

public interface IPaymentServiceService
{
    Task<PaymentServiceDTO> ServicePayment(CreatePaymentServiceModel model);
}
