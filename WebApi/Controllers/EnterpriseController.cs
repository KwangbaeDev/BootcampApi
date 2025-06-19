using Core.Interfaces.Services;
using Core.Requests.EnterpriseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class EnterpriseController : BaseApiController
    {
        private readonly IEnterpriseService _enterpriseService;

        public EnterpriseController(IEnterpriseService enterpriseService)
        {
            _enterpriseService = enterpriseService;
        }


        [HttpPost]
        //[Authorize(Roles = "Client")]
        public async Task<IActionResult> Create([FromBody] CreateEnterpriseModel request)
        {
            return Ok(await _enterpriseService.Add(request));
        }



        [HttpGet("{id}")]
        //[Authorize(Roles = "Client")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var enterprise = await _enterpriseService.GetById(id);
            return Ok(enterprise);
        }



        [HttpGet("all")]
        //[Authorize(Roles = "Client")]
        public async Task<IActionResult> GetAll()
        {
            var enterprise = await _enterpriseService.GettAll();
            return Ok(enterprise);
        }



        [HttpPut]
        //[Authorize(Roles = "Client")]
        public async Task<IActionResult> Update([FromBody] UpdateEnterpriseModel request)
        {
            return Ok(await _enterpriseService.Update(request));
        }



        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _enterpriseService.Delete(id));
        }
    }
}
