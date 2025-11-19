using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    public interface ICountryService
    {
        Task<ApiResponse<List<CountryGetDto>>> GetAllCountriesAsync();
        Task<ApiResponse<CountryGetDto>> GetCountryByIdAsync(long id);
        Task<ApiResponse<CountryGetDto>> CreateCountryAsync(CountryCreateDto countryCreateDto);
        Task<ApiResponse<CountryGetDto>> UpdateCountryAsync(long id, CountryUpdateDto countryUpdateDto);
        Task<ApiResponse<object>> DeleteCountryAsync(long id);
    }
}
