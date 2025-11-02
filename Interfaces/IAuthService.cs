using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    /// <summary>
    /// Authentication service interface for handling login and registration operations
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Authenticate user with username/email and password
        /// </summary>
        /// <param name="loginDto">Login credentials</param>
        /// <returns>Login response with token and user info</returns>
        Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto);

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="createUserDto">User registration data</param>
        /// <returns>Created user information</returns>
        Task<ApiResponse<UserDto>> RegisterAsync(CreateUserDto createUserDto);

        /// <summary>
        /// Validate user credentials
        /// </summary>
        /// <param name="usernameOrEmail">Username or email</param>
        /// <param name="password">Password</param>
        /// <returns>User if valid, null if invalid</returns>
        Task<Models.User?> ValidateUserAsync(string usernameOrEmail, string password);

        /// <summary>
        /// Check if email already exists
        /// </summary>
        /// <param name="email">Email to check</param>
        /// <returns>True if exists, false otherwise</returns>
        Task<bool> EmailExistsAsync(string email);

        /// <summary>
        /// Check if username already exists
        /// </summary>
        /// <param name="username">Username to check</param>
        /// <returns>True if exists, false otherwise</returns>
        Task<bool> UsernameExistsAsync(string username);
    }
}
