using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.ExtractionModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ExtractionController : BaseApiController
{
    private readonly IExtractionService _extractionService;

    public ExtractionController(IExtractionService extractionService)
    {
        _extractionService = extractionService;
    }


    [HttpPost]
    //[Authorize(Roles = "Client")]
    public async Task<IActionResult> ToExtract([FromBody] CreateExtractionModel request)
    {
        return Ok(await _extractionService.Extracting(request));
    }
}
