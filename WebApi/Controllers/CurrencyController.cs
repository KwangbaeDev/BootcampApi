using Core.Interfaces.Services;
using Core.Requests.CurrencyModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CurrencyController : BaseApiController
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    [HttpPost]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> Create([FromBody] CreateCurrencyModel request)
    {
        return Ok(await _currencyService.Add(request));
    }

    [HttpGet("filtered")]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> GetFeltered([FromQuery] FilterCurrencysModel filter)
    {
        var currency = await _currencyService.GetFiltered(filter);
        return Ok(currency);
    }

    [HttpGet("all")]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> GetAll()
    {
        var currency = await _currencyService.GetAll();
        return Ok(currency);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var currency = await _currencyService.GetById(id);
        return Ok(currency);
    }

    [HttpPut]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> Update([FromBody] UpdateCurrencyModel request)
    {
        return Ok(await _currencyService.Update(request));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _currencyService.Delete(id));
    }
}
