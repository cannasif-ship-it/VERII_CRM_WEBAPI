using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    /// <summary>
    /// User service interface for handling user management operations
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of users</returns>
        Task<ApiResponse<List<UserDto>>> GetAllUsersAsync();

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User information</returns>
        Task<ApiResponse<UserDto>> GetUserByIdAsync(int id);

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="createUserDto">User creation data</param>
        /// <returns>Created user information</returns>
        Task<ApiResponse<UserDto>> CreateUserAsync(CreateUserDto createUserDto);

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="updateUserDto">User update data</param>
        /// <returns>Updated user information</returns>
        Task<ApiResponse<UserDto>> UpdateUserAsync(int id, UpdateUserDto updateUserDto);

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Operation result</returns>
        Task<ApiResponse<object>> DeleteUserAsync(int id);

        /// <summary>
        /// Get users with pagination
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paged users</returns>
        Task<ApiResponse<PagedResult<UserDto>>> GetUsersPagedAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Check if user exists by username or email
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email</param>
        /// <returns>True if exists, false otherwise</returns>
        Task<bool> UserExistsAsync(string username, string email);

        /// <summary>
        /// Check if email is taken by another user
        /// </summary>
        /// <param name="email">Email to check</param>
        /// <param name="excludeUserId">User ID to exclude from check</param>
        /// <returns>True if taken, false otherwise</returns>
        Task<bool> IsEmailTakenByAnotherUserAsync(string email, int excludeUserId);
    }
}
