import { ApiResponse } from '../Models/ApiResponse';
import { CountryGetDto, CountryCreateDto, CountryUpdateDto } from '../Models/CountryDto';

export interface ICountryService {
  getAllCountries(): Promise<ApiResponse<CountryGetDto[]>>;
  getCountryById(id: number): Promise<ApiResponse<CountryGetDto>>;
  createCountry(countryCreateDto: CountryCreateDto): Promise<ApiResponse<CountryGetDto>>;
  updateCountry(id: number, countryUpdateDto: CountryUpdateDto): Promise<ApiResponse<CountryGetDto>>;
  deleteCountry(id: number): Promise<ApiResponse<object>>;
}