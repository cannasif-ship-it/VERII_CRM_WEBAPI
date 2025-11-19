using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<List<UserDto>>> GetAllUsersAsync();
        Task<ApiResponse<UserDto>> GetUserByIdAsync(long id);
        Task<ApiResponse<UserDto>> CreateUserAsync(CreateUserDto dto);
        Task<ApiResponse<UserDto>> UpdateUserAsync(long id, UpdateUserDto dto);
        Task<ApiResponse<object>> DeleteUserAsync(long id);
    }
}