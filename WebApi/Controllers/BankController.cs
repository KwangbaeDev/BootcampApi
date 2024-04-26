using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests.BankModels;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers;

public class BankController : BaseApiController
{
    private readonly IBankService _service;

    public BankController(IBankService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> Create([FromBody] CreateBankModel request)
    {
        return Ok(await _service.Add(request));
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var bank = await _service.GetById(id);
        return Ok(bank);
    }

    [HttpPut]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> Update([FromBody] UpdateBankModel request)
    {
        return Ok(await _service.Update(request));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _service.Delete(id));
    }

    [HttpGet("all")]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> GetAll()
    {
        var banks = await _service.GetAll();
        return Ok(banks);
    }
}
