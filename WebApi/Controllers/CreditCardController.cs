using Core.Interfaces.Services;
using Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CreditCardController : BaseApiController
{
    private readonly ICreditCardService _creditCardService;

    public CreditCardController(ICreditCardService creditCardService)
    {
        _creditCardService = creditCardService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCreditCardModel request)
    {
        return Ok(await _creditCardService.Add(request));
    }

    [HttpGet("filtered")]
    public async Task<IActionResult> GetFiltered([FromQuery] FilterCreditCardModel filter)
    {
        var creditCrad = await _creditCardService.GetFiltered(filter);
        return Ok(creditCrad);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var creditCard = await _creditCardService.GetAll();
        return Ok(creditCard);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var creditCard = await _creditCardService.GetById(id);
        return Ok(creditCard);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCreditCardModel request)
    {
        return Ok(await _creditCardService.Update(request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        return Ok(await _creditCardService.Delete(id));
    }
}
