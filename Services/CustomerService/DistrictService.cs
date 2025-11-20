using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;

namespace cms_webapi.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public DistrictService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<DistrictGetDto>>> GetAllDistrictsAsync()
        {
            try
            {
                var districts = await _unitOfWork.Districts.GetAllAsync();
                var districtDtos = _mapper.Map<List<DistrictGetDto>>(districts);

                return ApiResponse<List<DistrictGetDto>>.SuccessResult(districtDtos,_localizationService.GetLocalizedString("DistrictsRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<DistrictGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<DistrictGetDto>> GetDistrictByIdAsync(long id)
        {
            try
            {
                var district = await _unitOfWork.Districts.GetByIdAsync(id);
                if (district == null)
                {
                    return ApiResponse<DistrictGetDto>.ErrorResult(_localizationService.GetLocalizedString("DistrictNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var districtDto = _mapper.Map<DistrictGetDto>(district);
                return ApiResponse<DistrictGetDto>.SuccessResult(districtDto, _localizationService.GetLocalizedString("DistrictRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<DistrictGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<DistrictGetDto>> CreateDistrictAsync(DistrictCreateDto districtCreateDto)
        {
            try
            {
                var district = _mapper.Map<District>(districtCreateDto);
                var createdDistrict = await _unitOfWork.Districts.AddAsync(district);
                await _unitOfWork.SaveChangesAsync();

                var districtDto = _mapper.Map<DistrictGetDto>(createdDistrict);

                return ApiResponse<DistrictGetDto>.SuccessResult(districtDto, _localizationService.GetLocalizedString("DistrictCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<DistrictGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<DistrictGetDto>> UpdateDistrictAsync(long id, DistrictUpdateDto districtUpdateDto)
        {
            try
            {
                var district = await _unitOfWork.Districts.GetByIdAsync(id);
                if (district == null)
                {
                    return ApiResponse<DistrictGetDto>.ErrorResult(_localizationService.GetLocalizedString("DistrictNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(districtUpdateDto, district);
                var updatedDistrict = await _unitOfWork.Districts.UpdateAsync(district);
                await _unitOfWork.SaveChangesAsync();

                var districtDto = _mapper.Map<DistrictGetDto>(updatedDistrict);

                return ApiResponse<DistrictGetDto>.SuccessResult(districtDto, _localizationService.GetLocalizedString("DistrictUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<DistrictGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteDistrictAsync(long id)
        {
            try
            {
                var district = await _unitOfWork.Districts.GetByIdAsync(id);
                if (district == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("DistrictNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                await _unitOfWork.Districts.SoftDeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("DistrictDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
