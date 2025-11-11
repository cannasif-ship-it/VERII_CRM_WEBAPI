using cms_webapi.DTOs;
using cms_webapi.Models;

namespace cms_webapi.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<User>> GetUserByUsernameAsync(string username);
        Task<ApiResponse<User>> GetUserByIdAsync(int id);
        Task<ApiResponse<User>> RegisterUserAsync(RegisterDto registerDto);
        Task<ApiResponse<string>> LoginAsync(LoginDto loginDto);
    }
}