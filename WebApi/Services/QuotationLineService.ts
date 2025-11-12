import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { ApiResponse } from '../Models/ApiResponse';
import { QuotationLineDto, CreateQuotationLineDto, UpdateQuotationLineDto, QuotationLineGetDto } from '../Models/QuotationLineDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/QuotationLine',
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

export class QuotationLineService {
  async getAllQuotationLines(): Promise<ApiResponse<QuotationLineGetDto[]>> {
    try {
      const response = await api.get<ApiResponse<QuotationLineGetDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<QuotationLineGetDto[]>(error);
    }
  }

  async getQuotationLineById(id: number): Promise<ApiResponse<QuotationLineGetDto>> {
    try {
      const response = await api.get<ApiResponse<QuotationLineGetDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<QuotationLineGetDto>(error);
    }
  }

  async createQuotationLine(dto: CreateQuotationLineDto): Promise<ApiResponse<QuotationLineDto>> {
    try {
      const response = await api.post<ApiResponse<QuotationLineDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<QuotationLineDto>(error);
    }
  }

  async updateQuotationLine(id: number, dto: UpdateQuotationLineDto): Promise<ApiResponse<QuotationLineDto>> {
    try {
      const response = await api.put<ApiResponse<QuotationLineDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<QuotationLineDto>(error);
    }
  }

  async deleteQuotationLine(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }

  async getQuotationLinesByQuotationId(quotationId: number): Promise<ApiResponse<QuotationLineGetDto[]>> {
    try {
      const response = await api.get<ApiResponse<QuotationLineGetDto[]>>(`/by-quotation/${quotationId}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<QuotationLineGetDto[]>(error);
    }
  }
}