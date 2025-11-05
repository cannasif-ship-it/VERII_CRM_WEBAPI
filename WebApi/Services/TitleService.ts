import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { ITitleService } from '../Interfaces/ITitleService';
import { ApiResponse } from '../Models/ApiResponse';
import { TitleDto, CreateTitleDto, UpdateTitleDto } from '../Models/TitleDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/Title',
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

export class TitleService implements ITitleService {
  async getAllTitles(): Promise<ApiResponse<TitleDto[]>> {
    try {
      const response = await api.get<ApiResponse<TitleDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<TitleDto[]>(error);
    }
  }
  async getTitleById(id: number): Promise<ApiResponse<TitleDto>> {
    try {
      const response = await api.get<ApiResponse<TitleDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<TitleDto>(error);
    }
  }
  async createTitle(dto: CreateTitleDto): Promise<ApiResponse<TitleDto>> {
    try {
      const response = await api.post<ApiResponse<TitleDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<TitleDto>(error);
    }
  }
  async updateTitle(id: number, dto: UpdateTitleDto): Promise<ApiResponse<TitleDto>> {
    try {
      const response = await api.put<ApiResponse<TitleDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<TitleDto>(error);
    }
  }
  async deleteTitle(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}