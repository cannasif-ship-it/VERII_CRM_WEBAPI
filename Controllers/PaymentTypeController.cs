using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cms_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _paymentTypeService.GetAllPaymentTypesAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _paymentTypeService.GetPaymentTypeByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePaymentTypeDto createPaymentTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _paymentTypeService.CreatePaymentTypeAsync(createPaymentTypeDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UpdatePaymentTypeDto updatePaymentTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _paymentTypeService.UpdatePaymentTypeAsync(id, updatePaymentTypeDto);            
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _paymentTypeService.DeletePaymentTypeAsync(id); 
            return StatusCode(result.StatusCode, result);
        }
    }
}
