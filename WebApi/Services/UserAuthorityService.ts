import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { ApiResponse } from '../Models/ApiResponse';
import { UserAuthorityDto, CreateUserAuthorityDto, UpdateUserAuthorityDto } from '../Models/UserAuthorityDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/UserAuthority',
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

export class UserAuthorityService {
  async getAll(): Promise<ApiResponse<UserAuthorityDto[]>> {
    try {
      const response = await api.get<ApiResponse<UserAuthorityDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserAuthorityDto[]>(error);
    }
  }

  async getById(id: number): Promise<ApiResponse<UserAuthorityDto>> {
    try {
      const response = await api.get<ApiResponse<UserAuthorityDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserAuthorityDto>(error);
    }
  }

  async create(dto: CreateUserAuthorityDto): Promise<ApiResponse<UserAuthorityDto>> {
    try {
      const response = await api.post<ApiResponse<UserAuthorityDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserAuthorityDto>(error);
    }
  }

  async update(id: number, dto: UpdateUserAuthorityDto): Promise<ApiResponse<UserAuthorityDto>> {
    try {
      const response = await api.put<ApiResponse<UserAuthorityDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserAuthorityDto>(error);
    }
  }

  async softDelete(id: number): Promise<ApiResponse<boolean>> {
    try {
      const response = await api.delete<ApiResponse<boolean>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<boolean>(error);
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
}