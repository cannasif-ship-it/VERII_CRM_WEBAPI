import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IUserService } from '../Interfaces/IUserService';
import { ApiResponse, PagedResponse } from '../Models/ApiResponse';
import { UserDto, CreateUserDto, UpdateUserDto } from '../Models/UserDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/Users',
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

export class UserService implements IUserService {
  async getAllUsers(): Promise<ApiResponse<UserDto[]>> {
    try {
      const response = await api.get<ApiResponse<UserDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDto[]>(error);
    }
  }
  async getUserById(id: number): Promise<ApiResponse<UserDto>> {
    try {
      const response = await api.get<ApiResponse<UserDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDto>(error);
    }
  }
  async createUser(dto: CreateUserDto): Promise<ApiResponse<UserDto>> {
    try {
      const response = await api.post<ApiResponse<UserDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDto>(error);
    }
  }
  async updateUser(id: number, dto: UpdateUserDto): Promise<ApiResponse<UserDto>> {
    try {
      const response = await api.put<ApiResponse<UserDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDto>(error);
    }
  }
  async deleteUser(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
  async getUsersPaged(pageNumber: number, pageSize: number): Promise<ApiResponse<PagedResponse<UserDto>>> {
    try {
      const response = await api.get<ApiResponse<PagedResponse<UserDto>>>(`/paged?pageNumber=${pageNumber}&pageSize=${pageSize}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<PagedResponse<UserDto>>(error);
    }
  }
  async userExists(username: string, email: string): Promise<boolean> {
    try {
      const response = await api.get<boolean>(`/exists?username=${encodeURIComponent(username)}&email=${encodeURIComponent(email)}`);
      return response.data;
    } catch {
      return false;
    }
  }
  async isEmailTakenByAnotherUser(email: string, excludeUserId: number): Promise<boolean> {
    try {
      const response = await api.get<boolean>(`/is-email-taken?email=${encodeURIComponent(email)}&excludeUserId=${excludeUserId}`);
      return response.data;
    } catch {
      return false;
    }
  }
}