import { ApiResponse } from '../Models/ApiResponse';
import { CityGetDto, CityCreateDto, CityUpdateDto } from '../Models/CityDto';

export interface ICityService {
  getAllCities(): Promise<ApiResponse<CityGetDto[]>>;
  getCityById(id: number): Promise<ApiResponse<CityGetDto>>;
  createCity(cityCreateDto: CityCreateDto): Promise<ApiResponse<CityGetDto>>;
  updateCity(id: number, cityUpdateDto: CityUpdateDto): Promise<ApiResponse<CityGetDto>>;
  deleteCity(id: number): Promise<ApiResponse<object>>;
}