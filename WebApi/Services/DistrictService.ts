import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IDistrictService } from '../Interfaces/IDistrictService';
import { ApiResponse } from '../Models/ApiResponse';
import { DistrictGetDto, DistrictCreateDto, DistrictUpdateDto } from '../Models/DistrictDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/District',
  timeout: DEFAULT_TIMEOUT,
  headers: {
    'Content-Type': 'application/json',
    Accept: 'application/json',
    'X-Language': CURRENTLANGUAGE,
  },
});

api.interceptors.request.use((config: any) => {
  const token = getAuthToken();
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

export class DistrictService implements IDistrictService {
  async getAllDistricts(): Promise<ApiResponse<DistrictGetDto[]>> {
    try {
      const response = await api.get<ApiResponse<DistrictGetDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<DistrictGetDto[]>(error);
    }
  }
  async getDistrictById(id: number): Promise<ApiResponse<DistrictGetDto>> {
    try {
      const response = await api.get<ApiResponse<DistrictGetDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<DistrictGetDto>(error);
    }
  }
  async createDistrict(dto: DistrictCreateDto): Promise<ApiResponse<DistrictGetDto>> {
    try {
      const response = await api.post<ApiResponse<DistrictGetDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<DistrictGetDto>(error);
    }
  }
  async updateDistrict(id: number, dto: DistrictUpdateDto): Promise<ApiResponse<DistrictGetDto>> {
    try {
      const response = await api.put<ApiResponse<DistrictGetDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<DistrictGetDto>(error);
    }
  }
  async deleteDistrict(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}