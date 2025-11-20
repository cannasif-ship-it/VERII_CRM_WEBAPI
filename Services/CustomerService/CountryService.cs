using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;

namespace cms_webapi.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<CountryGetDto>>> GetAllCountriesAsync()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAllAsync();
                var countryDtos = _mapper.Map<List<CountryGetDto>>(countries);

                return ApiResponse<List<CountryGetDto>>.SuccessResult(countryDtos, _localizationService.GetLocalizedString("CountriesRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<CountryGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, 500);
            }
        }

        public async Task<ApiResponse<CountryGetDto>> GetCountryByIdAsync(long id)
        {
            try
            {
                var country = await _unitOfWork.Countries.GetByIdAsync(id);
                if (country == null)
                {
                    return ApiResponse<CountryGetDto>.ErrorResult(_localizationService.GetLocalizedString("CountryNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var countryDto = _mapper.Map<CountryGetDto>(country);
                return ApiResponse<CountryGetDto>.SuccessResult(countryDto, _localizationService.GetLocalizedString("CountryRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CountryGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<CountryGetDto>> CreateCountryAsync(CountryCreateDto countryCreateDto)
        {
            try
            {
                var country = _mapper.Map<Country>(countryCreateDto);
                var createdCountry = await _unitOfWork.Countries.AddAsync(country);
                await _unitOfWork.SaveChangesAsync();

                var countryDto = _mapper.Map<CountryGetDto>(createdCountry);

                return ApiResponse<CountryGetDto>.SuccessResult(countryDto, _localizationService.GetLocalizedString("CountryCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CountryGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<CountryGetDto>> UpdateCountryAsync(long id, CountryUpdateDto countryUpdateDto)
        {
            try
            {
                var country = await _unitOfWork.Countries.GetByIdAsync(id);
                if (country == null)
                {
                    return ApiResponse<CountryGetDto>.ErrorResult(_localizationService.GetLocalizedString("CountryNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(countryUpdateDto, country);
                var updatedCountry = await _unitOfWork.Countries.UpdateAsync(country);
                await _unitOfWork.SaveChangesAsync();

                var countryDto = _mapper.Map<CountryGetDto>(updatedCountry);

                return ApiResponse<CountryGetDto>.SuccessResult(countryDto, _localizationService.GetLocalizedString("CountryUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CountryGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteCountryAsync(long id)
        {
            try
            {
                var country = await _unitOfWork.Countries.GetByIdAsync(id);
                if (country == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("CountryNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                await _unitOfWork.Countries.SoftDeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("CountryDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
