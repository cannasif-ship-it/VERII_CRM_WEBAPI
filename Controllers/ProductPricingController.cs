using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cms_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductPricingController : ControllerBase
    {
        private readonly IProductPricingService _productPricingService;
        private readonly ILocalizationService _localizationService;

        public ProductPricingController(IProductPricingService productPricingService, ILocalizationService localizationService)
        {
            _productPricingService = productPricingService;
            _localizationService = localizationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _productPricingService.GetAllProductPricingsAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _productPricingService.GetProductPricingByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductPricingDto createProductPricingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("ValidationError"), "ValidationFailed", 400));
            }

            var result = await _productPricingService.CreateProductPricingAsync(createProductPricingDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UpdateProductPricingDto updateProductPricingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("ValidationError"), "ValidationFailed", 400));
            }

            var result = await _productPricingService.UpdateProductPricingAsync(id, updateProductPricingDto);            
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _productPricingService.DeleteProductPricingAsync(id); 
            return StatusCode(result.StatusCode, result);
        }
    }
}
