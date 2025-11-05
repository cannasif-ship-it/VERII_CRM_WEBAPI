import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IProductPricingService } from '../Interfaces/IProductPricingService';
import { ApiResponse } from '../Models/ApiResponse';
import { ProductPricingDto, CreateProductPricingDto, UpdateProductPricingDto } from '../Models/ProductPricingDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/ProductPricing',
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

export class ProductPricingService implements IProductPricingService {
  async getAllProductPricings(): Promise<ApiResponse<ProductPricingDto[]>> {
    try {
      const response = await api.get<ApiResponse<ProductPricingDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ProductPricingDto[]>(error);
    }
  }
  async getProductPricingById(id: number): Promise<ApiResponse<ProductPricingDto>> {
    try {
      const response = await api.get<ApiResponse<ProductPricingDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ProductPricingDto>(error);
    }
  }
  async createProductPricing(dto: CreateProductPricingDto): Promise<ApiResponse<ProductPricingDto>> {
    try {
      const response = await api.post<ApiResponse<ProductPricingDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ProductPricingDto>(error);
    }
  }
  async updateProductPricing(id: number, dto: UpdateProductPricingDto): Promise<ApiResponse<ProductPricingDto>> {
    try {
      const response = await api.put<ApiResponse<ProductPricingDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ProductPricingDto>(error);
    }
  }
  async deleteProductPricing(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}