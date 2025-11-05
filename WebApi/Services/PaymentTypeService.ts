import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IPaymentTypeService } from '../Interfaces/IPaymentTypeService';
import { ApiResponse } from '../Models/ApiResponse';
import { PaymentTypeDto, CreatePaymentTypeDto, UpdatePaymentTypeDto } from '../Models/PaymentTypeDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/PaymentType',
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

export class PaymentTypeService implements IPaymentTypeService {
  async getAllPaymentTypes(): Promise<ApiResponse<PaymentTypeDto[]>> {
    try {
      const response = await api.get<ApiResponse<PaymentTypeDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<PaymentTypeDto[]>(error);
    }
  }
  async getPaymentTypeById(id: number): Promise<ApiResponse<PaymentTypeDto>> {
    try {
      const response = await api.get<ApiResponse<PaymentTypeDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<PaymentTypeDto>(error);
    }
  }
  async createPaymentType(dto: CreatePaymentTypeDto): Promise<ApiResponse<PaymentTypeDto>> {
    try {
      const response = await api.post<ApiResponse<PaymentTypeDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<PaymentTypeDto>(error);
    }
  }
  async updatePaymentType(id: number, dto: UpdatePaymentTypeDto): Promise<ApiResponse<PaymentTypeDto>> {
    try {
      const response = await api.put<ApiResponse<PaymentTypeDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<PaymentTypeDto>(error);
    }
  }
  async deletePaymentType(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}