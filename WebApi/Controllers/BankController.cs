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
        return Ok(await _repository.Add(request));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var bank = await _repository.GetById(id);
        return Ok(bank);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBankModel request)
    {
        return Ok(await _repository.Update(request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _repository.Delete(id));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var banks = await _repository.GetAll();
        return Ok(banks);
    }
}
