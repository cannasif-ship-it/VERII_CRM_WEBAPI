import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { ICustomerService } from '../Interfaces/ICustomerService';
import { ApiResponse } from '../Models/ApiResponse';
import { CustomerGetDto, CustomerCreateDto, CustomerUpdateDto } from '../Models/CustomerDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/Customer',
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

export class CustomerService implements ICustomerService {
  async getAllCustomers(): Promise<ApiResponse<CustomerGetDto[]>> {
    try {
      const response = await api.get<ApiResponse<CustomerGetDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CustomerGetDto[]>(error);
    }
  }
  async getCustomerById(id: number): Promise<ApiResponse<CustomerGetDto>> {
    try {
      const response = await api.get<ApiResponse<CustomerGetDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CustomerGetDto>(error);
    }
  }
  async createCustomer(dto: CustomerCreateDto): Promise<ApiResponse<CustomerGetDto>> {
    try {
      const response = await api.post<ApiResponse<CustomerGetDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CustomerGetDto>(error);
    }
  }
  async updateCustomer(id: number, dto: CustomerUpdateDto): Promise<ApiResponse<CustomerGetDto>> {
    try {
      const response = await api.put<ApiResponse<CustomerGetDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<CustomerGetDto>(error);
    }
  }
  async deleteCustomer(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}