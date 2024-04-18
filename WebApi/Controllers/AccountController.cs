using Core.Interfaces.Services;
using Core.Requests.AccountModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class AccountController : BaseApiController
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateAccountModel request)
    {
        return Ok(await _accountService.Add(request));
    }

    [HttpGet("filtered")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetFiltered([FromQuery] FilterAccountModel filter)
    {
        var account = await _accountService.GetFiltered(filter);
        return Ok(account);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var account = await _accountService.GetById(id);
        return Ok(account);
    }

    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var account = await _accountService.GettAll();
        return Ok(account);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] UpdateAccountModel request)
    {
        return Ok(await _accountService.Update(request));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _accountService.Delete(id));
    }

}
