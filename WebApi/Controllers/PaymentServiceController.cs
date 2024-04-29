using Core.Interfaces.Services;
using Core.Requests.PaymentServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class PaymentServiceController : BaseApiController
{
    private readonly IPaymentServiceService _paymentService;

    public PaymentServiceController(IPaymentServiceService paymentServiceService)
    {
        _paymentService = paymentServiceService;
    }


    [HttpPost]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> PaymentForServices([FromBody] CreatePaymentServiceModel request)
    {
        return Ok(await _paymentService.ServicePayment(request));
    }
}
