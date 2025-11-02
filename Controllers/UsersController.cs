using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;

namespace cms_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // JWT token gerekli
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<UserDto>>>> GetUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            
            if (!result.Success)
            {
                return StatusCode(500, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<UserDto>>> GetById(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            
            if (!result.Success)
            {
                if (result.Message.Contains("NotFound"))
                {
                    return NotFound(result);
                }
                return StatusCode(500, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ApiResponse<UserDto>>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var result = await _userService.CreateUserAsync(createUserDto);
            
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data?.Id }, result);
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<UserDto>>> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var result = await _userService.UpdateUserAsync(id, updateUserDto);
            
            if (!result.Success)
            {
                if (result.Message.Contains("NotFound"))
                {
                    return NotFound(result);
                }
                return BadRequest(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            
            if (!result.Success)
            {
                if (result.Message.Contains("NotFound"))
                {
                    return NotFound(result);
                }
                return StatusCode(500, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get users with pagination
        /// </summary>
        [HttpGet("paged")]
        public async Task<ActionResult<ApiResponse<PagedResult<UserDto>>>> GetUsersPaged(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _userService.GetUsersPagedAsync(pageNumber, pageSize);
            
            if (!result.Success)
            {
                return StatusCode(500, result);
            }

            return Ok(result);
        }
    }
}
