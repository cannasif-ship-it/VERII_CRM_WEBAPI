import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IShippingAddressService } from '../Interfaces/IShippingAddressService';
import { ApiResponse } from '../Models/ApiResponse';
import { ShippingAddressGetDto, CreateShippingAddressDto, UpdateShippingAddressDto } from '../Models/ShippingAddressDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/ShippingAddress',
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

export class ShippingAddressService implements IShippingAddressService {
  async getAllShippingAddresses(): Promise<ApiResponse<ShippingAddressGetDto[]>> {
    try {
      const response = await api.get<ApiResponse<ShippingAddressGetDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ShippingAddressGetDto[]>(error);
    }
  }
  async getShippingAddressById(id: number): Promise<ApiResponse<ShippingAddressGetDto>> {
    try {
      const response = await api.get<ApiResponse<ShippingAddressGetDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ShippingAddressGetDto>(error);
    }
  }
  async getShippingAddressesByCustomerId(customerId: number): Promise<ApiResponse<ShippingAddressGetDto[]>> {
    try {
      const response = await api.get<ApiResponse<ShippingAddressGetDto[]>>(`/by-customer/${customerId}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ShippingAddressGetDto[]>(error);
    }
  }
  async createShippingAddress(dto: CreateShippingAddressDto): Promise<ApiResponse<ShippingAddressGetDto>> {
    try {
      const response = await api.post<ApiResponse<ShippingAddressGetDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ShippingAddressGetDto>(error);
    }
  }
  async updateShippingAddress(id: number, dto: UpdateShippingAddressDto): Promise<ApiResponse<ShippingAddressGetDto>> {
    try {
      const response = await api.put<ApiResponse<ShippingAddressGetDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ShippingAddressGetDto>(error);
    }
  }
  async deleteShippingAddress(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}