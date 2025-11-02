using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;

namespace cms_webapi.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<CityGetDto>>> GetAllCitiesAsync()
        {
            try
            {
                var cities = await _unitOfWork.Cities.GetAllAsync();
                var cityDtos = _mapper.Map<List<CityGetDto>>(cities);

                return ApiResponse<List<CityGetDto>>.SuccessResult
                (cityDtos, _localizationService.GetLocalizedString("CitiesRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<CityGetDto>>.ErrorResult
                (_localizationService.GetLocalizedString("InternalServerError"), ex.Message, 500);
            }
        }        

        public async Task<ApiResponse<CityGetDto>> GetCityByIdAsync(long id)
        {
            try
            {
                var city = await _unitOfWork.Cities.GetByIdAsync(id);
                if (city == null)
                {
                    return ApiResponse<CityGetDto>.ErrorResult(_localizationService.GetLocalizedString("CityNotFound"), "Not found", 404);
                }

                var cityDto = _mapper.Map<CityGetDto>(city);
                return ApiResponse<CityGetDto>.SuccessResult(cityDto, _localizationService.GetLocalizedString("CityRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CityGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, 500);
            }
        }

        public async Task<ApiResponse<CityGetDto>> CreateCityAsync(CityCreateDto cityCreateDto)
        {
            try
            {
                var city = _mapper.Map<City>(cityCreateDto);
                var createdCity = await _unitOfWork.Cities.AddAsync(city);
                await _unitOfWork.SaveChangesAsync();

                var cityDto = _mapper.Map<CityGetDto>(createdCity);

                return ApiResponse<CityGetDto>.SuccessResult(cityDto, _localizationService.GetLocalizedString("CityCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CityGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, 500);
            }
        }

        public async Task<ApiResponse<CityGetDto>> UpdateCityAsync(long id, CityUpdateDto cityUpdateDto)
        {
            try
            {
                var city = await _unitOfWork.Cities.GetByIdAsync(id);
                if (city == null)
                {
                    return ApiResponse<CityGetDto>.ErrorResult(_localizationService.GetLocalizedString("CityNotFound"), "Not found", 404);
                }

                _mapper.Map(cityUpdateDto, city);
                var updatedCity = await _unitOfWork.Cities.UpdateAsync(city);
                await _unitOfWork.SaveChangesAsync();

                var cityDto = _mapper.Map<CityGetDto>(updatedCity);

                return ApiResponse<CityGetDto>.SuccessResult(cityDto, _localizationService.GetLocalizedString("CityUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CityGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, 500);
            }
        }

        public async Task<ApiResponse<object>> DeleteCityAsync(long id)
        {
            try
            {
                var city = await _unitOfWork.Cities.GetByIdAsync(id);
                if (city == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("CityNotFound"), "Not found", 404);
                }

                await _unitOfWork.Cities.SoftDeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("CityDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
