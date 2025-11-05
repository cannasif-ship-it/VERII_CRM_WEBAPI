import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { ICityService } from '../Interfaces/ICityService';
import { ApiResponse } from '../Models/ApiResponse';
import { CityGetDto, CityCreateDto, CityUpdateDto } from '../Models/CityDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/City',
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

export class CityService implements ICityService {
  async getAllCities(): Promise<ApiResponse<CityGetDto[]>> {
    try {
      const response = await api.get<ApiResponse<CityGetDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CityGetDto[]>(error);
    }
  }
  async getCityById(id: number): Promise<ApiResponse<CityGetDto>> {
    try {
      const response = await api.get<ApiResponse<CityGetDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CityGetDto>(error);
    }
  }
  async createCity(dto: CityCreateDto): Promise<ApiResponse<CityGetDto>> {
    try {
      const response = await api.post<ApiResponse<CityGetDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CityGetDto>(error);
    }
  }
  async updateCity(id: number, dto: CityUpdateDto): Promise<ApiResponse<CityGetDto>> {
    try {
      const response = await api.put<ApiResponse<CityGetDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CityGetDto>(error);
    }
  }
  async deleteCity(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}