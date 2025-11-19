using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;

namespace cms_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserSessionController : ControllerBase
    {
        private readonly IUserSessionService _service;

        public UserSessionController(IUserSessionService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllSessionsAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetSessionByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserSessionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.CreateSessionAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{id}/revoke")]
        public async Task<IActionResult> Revoke(long id)
        {
            var result = await _service.RevokeSessionAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.DeleteSessionAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}