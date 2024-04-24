using Core.Interfaces.Services;
using Core.Requests.TransactionHistoryModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class TransactionHistoryController : BaseApiController
{
    private readonly ITransactionHistoryService _transactionHistoryService;

    public TransactionHistoryController(ITransactionHistoryService transactionHistoryService)
    {
        _transactionHistoryService = transactionHistoryService;
    }



    [HttpGet("filtered")]
    public async Task<IActionResult> GetFiltered([FromQuery] FilterTransactionHistoryModel filter)
    {
        var transactionHistory = await _transactionHistoryService.GetFiltered(filter);
        return Ok(transactionHistory);
    }
}
