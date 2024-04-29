using Core.Interfaces.Services;
using Core.Requests.PromotionModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PromotionController : BaseApiController
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }


        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create([FromBody] CreatePromotionModel request)
        {
            return Ok(await _promotionService.Add(request));
        }



        [HttpGet("filtered")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetFiltered([FromQuery] FilterPromotionModel filter)
        {
            var promotion = await _promotionService.GetFiltered(filter);
            return Ok(promotion);
        }



        [HttpGet("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var promotion = await _promotionService.GetById(id);
            return Ok(promotion);
        }



        [HttpGet("all")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetAll()
        {
            var promotion = await _promotionService.GettAll();
            return Ok(promotion);
        }



        [HttpPut]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Update([FromBody] UpdatePromotionModel request)
        {
            return Ok(await _promotionService.Update(request));
        }



        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _promotionService.Delete(id));
        }
    }
}
