using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace cms_webapi.Services
{
    public class UserDiscountLimitService : IUserDiscountLimitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public UserDiscountLimitService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<UserDiscountLimitDto>>> GetAllAsync()
        {
            try
            {
                var userDiscountLimits = await _unitOfWork.UserDiscountLimits.GetAllAsync();
                var userDiscountLimitDtos = _mapper.Map<List<UserDiscountLimitDto>>(userDiscountLimits);

                return ApiResponse<List<UserDiscountLimitDto>>.SuccessResult(userDiscountLimitDtos, _localizationService.GetLocalizedString("UserDiscountLimitsRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<UserDiscountLimitDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<UserDiscountLimitDto>> GetByIdAsync(long id)
        {
            try
            {
                var userDiscountLimit = await _unitOfWork.UserDiscountLimits.GetByIdAsync(id);
                if (userDiscountLimit == null)
                {
                    return ApiResponse<UserDiscountLimitDto>.ErrorResult(_localizationService.GetLocalizedString("UserDiscountLimitNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var userDiscountLimitDto = _mapper.Map<UserDiscountLimitDto>(userDiscountLimit);
                return ApiResponse<UserDiscountLimitDto>.SuccessResult(userDiscountLimitDto, _localizationService.GetLocalizedString("UserDiscountLimitRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDiscountLimitDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<List<UserDiscountLimitDto>>> GetBySalespersonIdAsync(long salespersonId)
        {
            try
            {
                var userDiscountLimits = await _unitOfWork.UserDiscountLimits
                    .FindAsync(x => x.SalespersonId == salespersonId);
                var userDiscountLimitDtos = _mapper.Map<List<UserDiscountLimitDto>>(userDiscountLimits);

                return ApiResponse<List<UserDiscountLimitDto>>.SuccessResult(userDiscountLimitDtos,_localizationService.GetLocalizedString("UserDiscountLimitsRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<UserDiscountLimitDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<List<UserDiscountLimitDto>>> GetByErpProductGroupCodeAsync(string erpProductGroupCode)
        {
            try
            {
                var userDiscountLimits = await _unitOfWork.UserDiscountLimits
                    .FindAsync(x => x.ErpProductGroupCode == erpProductGroupCode);
                var userDiscountLimitDtos = _mapper.Map<List<UserDiscountLimitDto>>(userDiscountLimits);

                return ApiResponse<List<UserDiscountLimitDto>>.SuccessResult(userDiscountLimitDtos, _localizationService.GetLocalizedString("UserDiscountLimitsRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<UserDiscountLimitDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<UserDiscountLimitDto>> GetBySalespersonAndGroupAsync(long salespersonId, string erpProductGroupCode)
        {
            try
            {
                var userDiscountLimit = await _unitOfWork.UserDiscountLimits
                    .FindAsync(x => x.SalespersonId == salespersonId && x.ErpProductGroupCode == erpProductGroupCode);
                var result = userDiscountLimit.FirstOrDefault();
                
                if (result == null)
                {
                    return ApiResponse<UserDiscountLimitDto>.ErrorResult(_localizationService.GetLocalizedString("UserDiscountLimitNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var userDiscountLimitDto = _mapper.Map<UserDiscountLimitDto>(result);
                return ApiResponse<UserDiscountLimitDto>.SuccessResult(userDiscountLimitDto, _localizationService.GetLocalizedString("UserDiscountLimitRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDiscountLimitDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<UserDiscountLimitDto>> CreateAsync(CreateUserDiscountLimitDto createDto)
        {
            try
            {
                var userDiscountLimit = _mapper.Map<UserDiscountLimit>(createDto);
                userDiscountLimit.CreatedDate = DateTime.UtcNow;
                
                await _unitOfWork.UserDiscountLimits.AddAsync(userDiscountLimit);
                await _unitOfWork.SaveChangesAsync();
                
                var userDiscountLimitDto = _mapper.Map<UserDiscountLimitDto>(userDiscountLimit);
                return ApiResponse<UserDiscountLimitDto>.SuccessResult(userDiscountLimitDto, _localizationService.GetLocalizedString("UserDiscountLimitCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDiscountLimitDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<UserDiscountLimitDto>> UpdateAsync(long id, UpdateUserDiscountLimitDto updateDto)
        {
            try
            {
                var existingUserDiscountLimit = await _unitOfWork.UserDiscountLimits.GetByIdAsync(id);
                if (existingUserDiscountLimit == null)
                {
                    return ApiResponse<UserDiscountLimitDto>.ErrorResult(_localizationService.GetLocalizedString("UserDiscountLimitNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(updateDto, existingUserDiscountLimit);
                existingUserDiscountLimit.UpdatedDate = DateTime.UtcNow;
                
                await _unitOfWork.UserDiscountLimits.UpdateAsync(existingUserDiscountLimit);
                await _unitOfWork.SaveChangesAsync();
                
                var userDiscountLimitDto = _mapper.Map<UserDiscountLimitDto>(existingUserDiscountLimit);
                return ApiResponse<UserDiscountLimitDto>.SuccessResult(userDiscountLimitDto, _localizationService.GetLocalizedString("UserDiscountLimitUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<UserDiscountLimitDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteAsync(long id)
        {
            try
            {
                var userDiscountLimit = await _unitOfWork.UserDiscountLimits.GetByIdAsync(id);
                if (userDiscountLimit == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("UserDiscountLimitNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                userDiscountLimit.IsDeleted = true;
                userDiscountLimit.DeletedDate = DateTime.UtcNow;
                
                await _unitOfWork.UserDiscountLimits.UpdateAsync(userDiscountLimit);
                await _unitOfWork.SaveChangesAsync();
                
                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("UserDiscountLimitDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<bool>> ExistsAsync(long id)
        {
            try
            {
                var exists = await _unitOfWork.UserDiscountLimits.ExistsAsync(id);
                return ApiResponse<bool>.SuccessResult(exists, _localizationService.GetLocalizedString("UserDiscountLimitExistsChecked"));
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<bool>> ExistsBySalespersonAndGroupAsync(long salespersonId, string erpProductGroupCode)
        {
            try
            {
                var userDiscountLimits = await _unitOfWork.UserDiscountLimits
                    .FindAsync(x => x.SalespersonId == salespersonId && x.ErpProductGroupCode == erpProductGroupCode);
                var exists = userDiscountLimits.Any();
                
                return ApiResponse<bool>.SuccessResult(exists, _localizationService.GetLocalizedString("UserDiscountLimitExistsChecked"));
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"),ex.Message,500);
            }
        }
    }
}
