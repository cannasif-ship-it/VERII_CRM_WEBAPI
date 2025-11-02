using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;

namespace cms_webapi.Services
{
    /// <summary>
    /// User service implementation
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of users</returns>
        public async Task<ApiResponse<List<UserDto>>> GetAllUsersAsync()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAllAsync();
                var userDtos = _mapper.Map<List<UserDto>>(users);

                return ApiResponse<List<UserDto>>.SuccessResult(userDtos, _localizationService.GetLocalizedString("UsersRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<UserDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, 500);
            }
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User information</returns>
        public async Task<ApiResponse<UserDto>> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(id);
                if (user == null)
                {
                    return ApiResponse<UserDto>.ErrorResult(_localizationService.GetLocalizedString("UserNotFound"), "User not found", 404);
                }

                var userDto = _mapper.Map<UserDto>(user);
                return ApiResponse<UserDto>.SuccessResult(userDto, _localizationService.GetLocalizedString("UserRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, 500);
            }
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="createUserDto">User creation data</param>
        /// <returns>Created user information</returns>
        public async Task<ApiResponse<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            try
            {
                // Check if email already exists
                if (await EmailExistsAsync(createUserDto.Email))
                {
                    return ApiResponse<UserDto>.ErrorResult(_localizationService.GetLocalizedString("EmailAlreadyExists"), "Email already exists", StatusCodes.Status409Conflict);
                }

                // Create new user
                var user = _mapper.Map<User>(createUserDto);
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);

                var createdUser = await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();
                var userDto = _mapper.Map<UserDto>(createdUser);

                return ApiResponse<UserDto>.SuccessResult(userDto, _localizationService.GetLocalizedString("UserCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, 500);
            }
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="updateUserDto">User update data</param>
        /// <returns>Updated user information</returns>
        public async Task<ApiResponse<UserDto>> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(id);
                if (user == null)
                {
                    return ApiResponse<UserDto>.ErrorResult(_localizationService.GetLocalizedString("UserNotFound"), "User not found", 404);
                }

                if (await EmailExistsForAnotherUserAsync(updateUserDto.Email, id))
                {
                    return ApiResponse<UserDto>.ErrorResult(_localizationService.GetLocalizedString("EmailAlreadyExists"), "Email already exists", StatusCodes.Status409Conflict);
                }

                // Update user properties
                _mapper.Map(updateUserDto, user);

                var updatedUser = await _unitOfWork.Users.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();
                var userDto = _mapper.Map<UserDto>(updatedUser);

                return ApiResponse<UserDto>.SuccessResult(userDto, _localizationService.GetLocalizedString("UserUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, 500);
            }
        }

        /// <summary>
        /// Delete a user (soft delete)
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Deletion result</returns>
        public async Task<ApiResponse<object>> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(id);
                if (user == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("UserNotFound"), "User not found", 404);
                }

                await _unitOfWork.Users.SoftDeleteAsync(user.Id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("UserDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, 500);
            }
        }

        /// <summary>
        /// Get users with pagination
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paginated users</returns>
        public async Task<ApiResponse<PagedResult<UserDto>>> GetUsersPagedAsync(int pageNumber, int pageSize)
        {
            try
            {
                var pagedUsers = await _unitOfWork.Users.GetPagedAsync(pageNumber, pageSize);
                var userDtos = _mapper.Map<List<UserDto>>(pagedUsers);
                
                // Get total count separately
                var totalCount = await _unitOfWork.Users.CountAsync();
                
                var pagedResult = new PagedResult<UserDto>
                {
                    Items = userDtos,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                return ApiResponse<PagedResult<UserDto>>.SuccessResult(pagedResult, _localizationService.GetLocalizedString("UsersRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<PagedResult<UserDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, 500);
            }
        }

        /// <summary>
        /// Check if email already exists
        /// </summary>
        /// <param name="email">Email to check</param>
        /// <returns>True if exists, false otherwise</returns>
        public async Task<bool> EmailExistsAsync(string email)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user != null;
        }

        /// <summary>
        /// Check if email exists for another user (used in updates)
        /// </summary>
        /// <param name="email">Email to check</param>
        /// <param name="excludeUserId">User ID to exclude from check</param>
        /// <returns>True if exists for another user, false otherwise</returns>
        public async Task<bool> EmailExistsForAnotherUserAsync(string email, int excludeUserId)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == email && u.Id != excludeUserId);
            return user != null;
        }

        /// <summary>
        /// Check if user exists by username or email
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email</param>
        /// <returns>True if exists, false otherwise</returns>
        public async Task<bool> UserExistsAsync(string username, string email)
        {
            var existingUser = await _unitOfWork.Users.FirstOrDefaultAsync(u => 
                u.Username == username || u.Email == email);
            return existingUser != null;
        }

        /// <summary>
        /// Check if email is taken by another user
        /// </summary>
        /// <param name="email">Email to check</param>
        /// <param name="excludeUserId">User ID to exclude from check</param>
        /// <returns>True if taken, false otherwise</returns>
        public async Task<bool> IsEmailTakenByAnotherUserAsync(string email, int excludeUserId)
        {
            var existingUser = await _unitOfWork.Users.FirstOrDefaultAsync(u => 
                u.Email == email && u.Id != excludeUserId);
            return existingUser != null;
        }
    }
}
