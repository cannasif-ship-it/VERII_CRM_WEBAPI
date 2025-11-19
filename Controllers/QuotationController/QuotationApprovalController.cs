using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;

namespace cms_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class QuotationApprovalController : ControllerBase
    {
        private readonly IQuotationApprovalService _service;

        public QuotationApprovalController(IQuotationApprovalService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllQuotationApprovalsAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetQuotationApprovalByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateQuotationApprovalDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateQuotationApprovalAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UpdateQuotationApprovalDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.UpdateQuotationApprovalAsync(id, dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeleteQuotationApprovalAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}