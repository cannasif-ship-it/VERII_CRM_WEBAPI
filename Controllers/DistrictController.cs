using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cms_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _districtService.GetAllDistrictsAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _districtService.GetDistrictByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DistrictCreateDto districtCreateDto)
        {
            var result = await _districtService.CreateDistrictAsync(districtCreateDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] DistrictUpdateDto districtUpdateDto)
        {
            var result = await _districtService.UpdateDistrictAsync(id, districtUpdateDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _districtService.DeleteDistrictAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
