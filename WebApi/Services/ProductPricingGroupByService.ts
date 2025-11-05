import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IProductPricingGroupByService } from '../Interfaces/IProductPricingGroupByService';
import { ApiResponse } from '../Models/ApiResponse';
import { ProductPricingGroupByDto, CreateProductPricingGroupByDto, UpdateProductPricingGroupByDto } from '../Models/ProductPricingGroupByDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/ProductPricingGroupBy',
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

export class ProductPricingGroupByService implements IProductPricingGroupByService {
  async getAllProductPricingGroupBys(): Promise<ApiResponse<ProductPricingGroupByDto[]>> {
    try {
      const response = await api.get<ApiResponse<ProductPricingGroupByDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ProductPricingGroupByDto[]>(error);
    }
  }
  async getProductPricingGroupByById(id: number): Promise<ApiResponse<ProductPricingGroupByDto>> {
    try {
      const response = await api.get<ApiResponse<ProductPricingGroupByDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ProductPricingGroupByDto>(error);
    }
  }
  async createProductPricingGroupBy(dto: CreateProductPricingGroupByDto): Promise<ApiResponse<ProductPricingGroupByDto>> {
    try {
      const response = await api.post<ApiResponse<ProductPricingGroupByDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ProductPricingGroupByDto>(error);
    }
  }
  async updateProductPricingGroupBy(id: number, dto: UpdateProductPricingGroupByDto): Promise<ApiResponse<ProductPricingGroupByDto>> {
    try {
      const response = await api.put<ApiResponse<ProductPricingGroupByDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ProductPricingGroupByDto>(error);
    }
  }
  async deleteProductPricingGroupBy(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}