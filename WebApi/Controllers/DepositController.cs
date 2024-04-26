using Core.Interfaces.Services;
using Core.Requests.DepositModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class DepositController : BaseApiController
{
    private readonly IDepositService _depositService;

    public DepositController(IDepositService depositService)
    {
        _depositService = depositService;
    }


    [HttpPost]
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> ToDeposit([FromBody] CreateDepositModel request)
    {
        return Ok(await _depositService.Depositing(request));
    }
}
