using Core.Interfaces.Services;
using Core.Requests.ApplicationFormModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ApplicationFormController : BaseApiController
    {
        private readonly IApplicationFormService _applicationFormService;

        public ApplicationFormController(IApplicationFormService applicationFormService)
        {
            _applicationFormService = applicationFormService;
        }


        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CreateApplicationForm([FromBody] CreateApplicationFormModel request)
        {
            return Ok(await _applicationFormService.CreateApplicationForm(request));
        }



        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateApplicationForm([FromBody] UpdateApplicationFormModel request)
        {
            return Ok(await _applicationFormService.Update(request));
        }
    }
}
