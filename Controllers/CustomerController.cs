using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cms_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _customerService.GetAllCustomersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _customerService.GetCustomerByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerCreateDto customerCreateDto)
        {
            var result = await _customerService.CreateCustomerAsync(customerCreateDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CustomerUpdateDto customerUpdateDto)
        {
            var result = await _customerService.UpdateCustomerAsync(id, customerUpdateDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
