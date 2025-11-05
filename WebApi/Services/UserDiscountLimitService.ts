import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IUserDiscountLimitService } from '../Interfaces/IUserDiscountLimitService';
import { ApiResponse } from '../Models/ApiResponse';
import { UserDiscountLimitDto, CreateUserDiscountLimitDto, UpdateUserDiscountLimitDto } from '../Models/UserDiscountLimitDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/UserDiscountLimit',
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

export class UserDiscountLimitService implements IUserDiscountLimitService {
  async getAll(): Promise<ApiResponse<UserDiscountLimitDto[]>> {
    try {
      const response = await api.get<ApiResponse<UserDiscountLimitDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDiscountLimitDto[]>(error);
    }
  }
  async getById(id: number): Promise<ApiResponse<UserDiscountLimitDto>> {
    try {
      const response = await api.get<ApiResponse<UserDiscountLimitDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDiscountLimitDto>(error);
    }
  }
  async getBySalespersonId(salespersonId: number): Promise<ApiResponse<UserDiscountLimitDto[]>> {
    try {
      const response = await api.get<ApiResponse<UserDiscountLimitDto[]>>(`/by-salesperson/${salespersonId}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDiscountLimitDto[]>(error);
    }
  }
  async getByErpProductGroupCode(erpProductGroupCode: string): Promise<ApiResponse<UserDiscountLimitDto[]>> {
    try {
      const response = await api.get<ApiResponse<UserDiscountLimitDto[]>>(`/by-group/${encodeURIComponent(erpProductGroupCode)}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDiscountLimitDto[]>(error);
    }
  }
  async getBySalespersonAndGroup(salespersonId: number, erpProductGroupCode: string): Promise<ApiResponse<UserDiscountLimitDto>> {
    try {
      const response = await api.get<ApiResponse<UserDiscountLimitDto>>(`/by-salesperson-group?salespersonId=${salespersonId}&erpProductGroupCode=${encodeURIComponent(erpProductGroupCode)}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDiscountLimitDto>(error);
    }
  }
  async create(createDto: CreateUserDiscountLimitDto): Promise<ApiResponse<UserDiscountLimitDto>> {
    try {
      const response = await api.post<ApiResponse<UserDiscountLimitDto>>('/', createDto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDiscountLimitDto>(error);
    }
  }
  async update(id: number, updateDto: UpdateUserDiscountLimitDto): Promise<ApiResponse<UserDiscountLimitDto>> {
    try {
      const response = await api.put<ApiResponse<UserDiscountLimitDto>>(`/${id}`, updateDto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDiscountLimitDto>(error);
    }
  }
  async delete(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
  async exists(id: number): Promise<ApiResponse<boolean>> {
    try {
      const response = await api.get<ApiResponse<boolean>>(`/${id}/exists`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<boolean>(error);
    }
  }
  async existsBySalespersonAndGroup(salespersonId: number, erpProductGroupCode: string): Promise<ApiResponse<boolean>> {
    try {
      const response = await api.get<ApiResponse<boolean>>(`/exists-by-salesperson-group?salespersonId=${salespersonId}&erpProductGroupCode=${encodeURIComponent(erpProductGroupCode)}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<boolean>(error);
    }
  }
}