import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IActivityService } from '../Interfaces/IActivityService';
import { ApiResponse } from '../Models/ApiResponse';
import { ActivityDto, CreateActivityDto, UpdateActivityDto } from '../Models/ActivityDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/Activity',
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

export class ActivityService implements IActivityService {
  
  async getAllActivities(): Promise<ApiResponse<ActivityDto[]>> {
    try {
      const response = await api.get<ApiResponse<ActivityDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ActivityDto[]>(error);
    }
  }

  async getActivityById(id: number): Promise<ApiResponse<ActivityDto>> {
    try {
      const response = await api.get<ApiResponse<ActivityDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ActivityDto>(error);
    }
  }

  async createActivity(createDto: CreateActivityDto): Promise<ApiResponse<ActivityDto>> {
    try {
      const response = await api.post<ApiResponse<ActivityDto>>('/', createDto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ActivityDto>(error);
    }
  }

  async updateActivity(id: number, updateDto: UpdateActivityDto): Promise<ApiResponse<ActivityDto>> {
    try {
      const response = await api.put<ApiResponse<ActivityDto>>(`/${id}`, updateDto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ActivityDto>(error);
    }
  }

  async deleteActivity(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}