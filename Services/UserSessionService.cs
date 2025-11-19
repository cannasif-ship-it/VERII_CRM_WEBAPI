using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace cms_webapi.Services
{
    public class UserSessionService : IUserSessionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _loc;

        public UserSessionService(IUnitOfWork uow, IMapper mapper, ILocalizationService loc)
        {
            _uow = uow; _mapper = mapper; _loc = loc;
        }

        public async Task<ApiResponse<List<UserSessionDto>>> GetAllSessionsAsync()
        {
            try
            {
                var items = await _uow.UserSessions.GetAllAsync();
                var dtos = _mapper.Map<List<UserSessionDto>>(items.ToList());
                return ApiResponse<List<UserSessionDto>>.SuccessResult(dtos, _loc.GetLocalizedString("UserSessionsRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<UserSessionDto>>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<UserSessionDto>> GetSessionByIdAsync(long id)
        {
            try
            {
                var item = await _uow.UserSessions.GetByIdAsync(id);
                if (item == null) return ApiResponse<UserSessionDto>.ErrorResult(_loc.GetLocalizedString("UserSessionNotFound"), "Not found", StatusCodes.Status404NotFound);
                var dto = _mapper.Map<UserSessionDto>(item);
                return ApiResponse<UserSessionDto>.SuccessResult(dto, _loc.GetLocalizedString("UserSessionRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserSessionDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<UserSessionDto>> CreateSessionAsync(CreateUserSessionDto dto)
        {
            try
            {
                var entity = _mapper.Map<UserSession>(dto);
                await _uow.UserSessions.AddAsync(entity);
                await _uow.SaveChangesAsync();
                var outDto = _mapper.Map<UserSessionDto>(entity);
                return ApiResponse<UserSessionDto>.SuccessResult(outDto, _loc.GetLocalizedString("UserSessionCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserSessionDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> RevokeSessionAsync(long id)
        {
            try
            {
                var entity = await _uow.UserSessions.GetByIdAsync(id);
                if (entity == null) return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("UserSessionNotFound"), "Not found", StatusCodes.Status404NotFound);
                entity.RevokedAt = DateTime.UtcNow;
                await _uow.UserSessions.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<object>.SuccessResult(null, _loc.GetLocalizedString("UserSessionRevoked"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteSessionAsync(long id)
        {
            try
            {
                var entity = await _uow.UserSessions.GetByIdAsync(id);
                if (entity == null) return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("UserSessionNotFound"), "Not found", StatusCodes.Status404NotFound);
                await _uow.UserSessions.SoftDeleteAsync(id);
                await _uow.SaveChangesAsync();
                return ApiResponse<object>.SuccessResult(null, _loc.GetLocalizedString("UserSessionDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}