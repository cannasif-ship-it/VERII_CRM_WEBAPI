using AutoMapper;
using BCrypt.Net;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;

namespace cms_webapi.Services
{
    /// <summary>
    /// Authentication service implementation
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public AuthService(
            IUnitOfWork unitOfWork,
            IJwtTokenService jwtTokenService,
            IMapper mapper,
            ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        /// <summary>
        /// Authenticate user with username/email and password
        /// </summary>
        /// <param name="loginDto">Login credentials</param>
        /// <returns>Login response with token and user info</returns>
        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            try
            {
                // Validate user credentials
                var user = await ValidateUserAsync(loginDto.UsernameOrEmail, loginDto.Password);
                if (user == null)
                {
                    return ApiResponse<LoginResponseDto>.ErrorResult(_localizationService.GetLocalizedString("InvalidCredentials"), "Invalid credentials", StatusCodes.Status401Unauthorized);
                }

                // Check if user is active
                if (user.IsDeleted)
                {
                    return ApiResponse<LoginResponseDto>.ErrorResult(_localizationService.GetLocalizedString("AccountInactive"), "Account is inactive", StatusCodes.Status403Forbidden);
                }

                // Generate JWT token
                var token = _jwtTokenService.GenerateToken(user);
                var expiresAt = DateTime.UtcNow.AddMinutes(_jwtTokenService.GetTokenExpirationMinutes());

                var userDto = _mapper.Map<UserDto>(user);
                var response = new LoginResponseDto
                {
                    Token = token,
                    ExpiresAt = expiresAt,
                    User = userDto
                };

                return ApiResponse<LoginResponseDto>.SuccessResult(response, _localizationService.GetLocalizedString("LoginSuccessful"));
            }
            catch (Exception ex)
            {
                return ApiResponse<LoginResponseDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="createUserDto">User registration data</param>
        /// <returns>Created user information</returns>
        public async Task<ApiResponse<UserDto>> RegisterAsync(CreateUserDto createUserDto)
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

                return ApiResponse<UserDto>.SuccessResult(userDto, _localizationService.GetLocalizedString("UserRegistered"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Validate user credentials
        /// </summary>
        /// <param name="usernameOrEmail">Username or email</param>
        /// <param name="password">Password</param>
        /// <returns>User if valid, null if invalid</returns>
        public async Task<User?> ValidateUserAsync(string usernameOrEmail, string password)
        {
            // Find user by email or username
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => 
                u.Email == usernameOrEmail || u.Username == usernameOrEmail);

            if (user == null)
                return null;

            // Verify password
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return user;
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
        /// Check if username already exists
        /// </summary>
        /// <param name="username">Username to check</param>
        /// <returns>True if exists, false otherwise</returns>
        public async Task<bool> UsernameExistsAsync(string username)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user != null;
        }
    }
}
