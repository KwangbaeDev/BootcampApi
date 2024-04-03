using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BankController : BaseApiController
{
    private readonly IBankRepository _repository;

    public BankController(IBankRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBankModel request)
    {
        await _repository.Add(request);

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var bank = await _repository.GetById(id);
        return Ok(bank);
    }
}
