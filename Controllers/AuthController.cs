using Microsoft.AspNetCore.Mvc;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;

namespace cms_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Kullanıcı girişi yapar ve JWT token döner
        /// </summary>
        /// <param name="loginDto">Giriş bilgileri</param>
        /// <returns>JWT token ve kullanıcı bilgileri</returns>
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<LoginResponseDto>>> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Kullanıcı kaydı yapar
        /// </summary>
        /// <param name="createUserDto">Kullanıcı bilgileri</param>
        /// <returns>Oluşturulan kullanıcı bilgileri</returns>
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<UserDto>>> Register([FromBody] CreateUserDto createUserDto)
        {
            var result = await _authService.RegisterAsync(createUserDto);
            
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetUserById), "Users", new { id = result.Data?.Id }, result);
        }

        private async Task<ActionResult<ApiResponse<UserDto>>> GetUserById()
        {
            // This method is kept for CreatedAtAction reference
            // In a real scenario, this would be handled by UsersController
            return Ok();
        }
    }
}
