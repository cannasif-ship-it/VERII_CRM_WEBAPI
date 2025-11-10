import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { ICustomerTypeService } from '../Interfaces/ICustomerTypeService';
import { ApiResponse } from '../Models/ApiResponse';
import { CustomerTypeGetDto, CustomerTypeCreateDto, CustomerTypeUpdateDto } from '../Models/CustomerTypeDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/CustomerType',
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

export class CustomerTypeService implements ICustomerTypeService {
  async getAllCustomerTypes(): Promise<ApiResponse<CustomerTypeGetDto[]>> {
    try {
      const response = await api.get<ApiResponse<CustomerTypeGetDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CustomerTypeGetDto[]>(error);
    }
  }
  async getCustomerTypeById(id: number): Promise<ApiResponse<CustomerTypeGetDto>> {
    try {
      const response = await api.get<ApiResponse<CustomerTypeGetDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CustomerTypeGetDto>(error);
    }
  }
  async createCustomerType(dto: CustomerTypeCreateDto): Promise<ApiResponse<CustomerTypeGetDto>> {
    try {
      const response = await api.post<ApiResponse<CustomerTypeGetDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CustomerTypeGetDto>(error);
    }
  }
  async updateCustomerType(id: number, dto: CustomerTypeUpdateDto): Promise<ApiResponse<CustomerTypeGetDto>> {
    try {
      const response = await api.put<ApiResponse<CustomerTypeGetDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CustomerTypeGetDto>(error);
    }
  }
  async deleteCustomerType(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}