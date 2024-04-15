using Core.Interfaces.Services;
using Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class Company_BusinessController : BaseApiController
    {
        private readonly ICompany_BusinessService _companyService;

        public Company_BusinessController(ICompany_BusinessService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create([FromBody] CreateCompany_BusinessModel request)
        {
            return Ok(await _companyService.Add(request));
        }


        [HttpGet("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var companyBusiness = await _companyService.GetById(id);
            return Ok(companyBusiness);
        }


        [HttpGet("all")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAll()
        {
            var companyBusiness = await _companyService.GettAll();
            return Ok(companyBusiness);
        }


        [HttpPut]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateCompany_BusinessModel request)
        {
            return Ok(await _companyService.Update(request));
        }


        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _companyService.Delete(id));
        }

    }
}
