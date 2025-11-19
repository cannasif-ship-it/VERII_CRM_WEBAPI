using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace cms_webapi.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _loc;

        public UserService(IUnitOfWork uow, IMapper mapper, ILocalizationService loc)
        {
            _uow = uow; _mapper = mapper; _loc = loc;
        }

        public async Task<ApiResponse<List<UserDto>>> GetAllUsersAsync()
        {
            try
            {
                var users = await _uow.Users.GetAllAsync();
                var dtos = _mapper.Map<List<UserDto>>(users.ToList());
                return ApiResponse<List<UserDto>>.SuccessResult(dtos, _loc.GetLocalizedString("UsersRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<UserDto>>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<UserDto>> GetUserByIdAsync(long id)
        {
            try
            {
                var user = await _uow.Users.GetByIdAsync(id);
                if (user == null) return ApiResponse<UserDto>.ErrorResult(_loc.GetLocalizedString("UserNotFound"), "Not found", StatusCodes.Status404NotFound);
                var dto = _mapper.Map<UserDto>(user);
                return ApiResponse<UserDto>.SuccessResult(dto, _loc.GetLocalizedString("UserRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<UserDto>> CreateUserAsync(CreateUserDto dto)
        {
            try
            {
                var entity = _mapper.Map<User>(dto);
                entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
                entity.CreatedDate = DateTime.UtcNow;
                await _uow.Users.AddAsync(entity);
                await _uow.SaveChangesAsync();
                var outDto = _mapper.Map<UserDto>(entity);
                return ApiResponse<UserDto>.SuccessResult(outDto, _loc.GetLocalizedString("UserCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<UserDto>> UpdateUserAsync(long id, UpdateUserDto dto)
        {
            try
            {
                var entity = await _uow.Users.GetByIdAsync(id);
                if (entity == null) return ApiResponse<UserDto>.ErrorResult(_loc.GetLocalizedString("UserNotFound"), "Not found", StatusCodes.Status404NotFound);
                _mapper.Map(dto, entity);
                entity.UpdatedDate = DateTime.UtcNow;
                await _uow.Users.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                var outDto = _mapper.Map<UserDto>(entity);
                return ApiResponse<UserDto>.SuccessResult(outDto, _loc.GetLocalizedString("UserUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteUserAsync(long id)
        {
            try
            {
                var entity = await _uow.Users.GetByIdAsync(id);
                if (entity == null) return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("UserNotFound"), "Not found", StatusCodes.Status404NotFound);
                await _uow.Users.SoftDeleteAsync(id);
                await _uow.SaveChangesAsync();
                return ApiResponse<object>.SuccessResult(null, _loc.GetLocalizedString("UserDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}