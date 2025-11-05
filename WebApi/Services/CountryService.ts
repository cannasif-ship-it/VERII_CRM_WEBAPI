import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { ICountryService } from '../Interfaces/ICountryService';
import { ApiResponse } from '../Models/ApiResponse';
import { CountryGetDto, CountryCreateDto, CountryUpdateDto } from '../Models/CountryDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/Country',
  timeout: DEFAULT_TIMEOUT,
  headers: {
    'Content-Type': 'application/json',
    Accept: 'application/json',
    'X-Language': CURRENTLANGUAGE,
  },
});

api.interceptors.request.use((config: AxiosRequestConfig) => {
  const token = getAuthToken();
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

export class CountryService implements ICountryService {
  async getAllCountries(): Promise<ApiResponse<CountryGetDto[]>> {
    try {
      const response = await api.get<ApiResponse<CountryGetDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CountryGetDto[]>(error);
    }
  }
  async getCountryById(id: number): Promise<ApiResponse<CountryGetDto>> {
    try {
      const response = await api.get<ApiResponse<CountryGetDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CountryGetDto>(error);
    }
  }
  async createCountry(dto: CountryCreateDto): Promise<ApiResponse<CountryGetDto>> {
    try {
      const response = await api.post<ApiResponse<CountryGetDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CountryGetDto>(error);
    }
  }
  async updateCountry(id: number, dto: CountryUpdateDto): Promise<ApiResponse<CountryGetDto>> {
    try {
      const response = await api.put<ApiResponse<CountryGetDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CountryGetDto>(error);
    }
  }
  async deleteCountry(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}