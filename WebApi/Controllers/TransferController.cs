using Core.Interfaces.Services;
using Core.Requests.TransferModels;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class TransferController : BaseApiController
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }


        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> MakeTransfer([FromBody] CreateTransferModel request)
        {
            return Ok(await _transferService.Transferred(request));
        }
    }
}
