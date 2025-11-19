using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    public interface IUserSessionService
    {
        Task<ApiResponse<List<UserSessionDto>>> GetAllSessionsAsync();
        Task<ApiResponse<UserSessionDto>> GetSessionByIdAsync(long id);
        Task<ApiResponse<UserSessionDto>> CreateSessionAsync(CreateUserSessionDto dto);
        Task<ApiResponse<object>> RevokeSessionAsync(long id);
        Task<ApiResponse<object>> DeleteSessionAsync(long id);
    }
}