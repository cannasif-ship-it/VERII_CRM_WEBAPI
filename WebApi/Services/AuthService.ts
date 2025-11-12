import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken, setAuthToken, removeAuthToken } from '../baseUrl';
import { ApiResponse } from '../Models/ApiResponse';
import { LoginDto, LoginResponseDto } from '../Models/AuthDto';
import { UserDto } from '../Models/UserDto';
import { IAuthService } from '../Interfaces/IAuthService';

const api = axios.create({
  baseURL: API_BASE_URL + '/auth',
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

export class AuthService implements IAuthService {
  async login(loginDto: LoginDto): Promise<ApiResponse<LoginResponseDto>> {
    try {
      // Backend LoginRequest: { email, password }
      const payload = { email: loginDto.usernameOrEmail, password: loginDto.password };
      const response = await api.post<ApiResponse<{ token: string }>>('/login', payload);
      const token = (response.data as any)?.data?.token;
      let user: UserDto | undefined = undefined;
      let expiresAt = '';

      if (token) {
        setAuthToken(token);
        // Decode JWT exp claim if present to populate expiresAt
        try {
          const parts = token.split('.');
          if (parts.length === 3) {
            const payloadJson = JSON.parse(atob(parts[1].replace(/-/g, '+').replace(/_/g, '/')));
            if (payloadJson && payloadJson.exp) {
              expiresAt = new Date(payloadJson.exp * 1000).toISOString();
            }
          }
        } catch {}

        // Try to fetch profile to populate user
        try {
          const profile = await api.get<ApiResponse<UserDto>>('/user');
          user = profile.data?.data;
        } catch {
          // ignore profile errors, token is sufficient for login success
        }
      }

      const result: ApiResponse<LoginResponseDto> = {
        success: response.data.success,
        message: response.data.message,
        exceptionMessage: response.data.exceptionMessage,
        statusCode: response.data.statusCode,
        data: token ? { token, expiresAt, user: (user as UserDto) ?? ({} as UserDto) } : undefined,
        errors: response.data.errors,
        timestamp: response.data.timestamp,
        className: 'ApiResponse'
      };
      return result;
    } catch (error) {
      return ApiResponseErrorHelper.create<LoginResponseDto>(error);
    }
  }

  async adminLogin(): Promise<ApiResponse<{ token: string }>> {
    try {
      const response = await api.post<ApiResponse<{ token: string }>>('/admin-login');
      const token = response.data?.data?.token;
      if (token) setAuthToken(token);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<{ token: string }>(error);
    }
  }

  async register(createUserDto: import('../Models/UserDto').CreateUserDto): Promise<ApiResponse<UserDto>> {
    return {
      success: false,
      message: 'register endpointi tanımlı değil',
      exceptionMessage: 'NotImplemented',
      data: undefined,
      errors: [],
      timestamp: new Date().toISOString(),
      statusCode: 501,
      className: 'ApiResponse'
    };
  }

  async validateUser(usernameOrEmail: string, password: string): Promise<import('../Models/User').User | null> {
    // Backend tarafında ayrı bir validate endpointi yok, login ile doğrulanıyor.
    return null;
  }

  async emailExists(email: string): Promise<boolean> {
    // Backend tarafında doğrudan bir kontrol endpointi tanımlı değil.
    return false;
  }

  async usernameExists(username: string): Promise<boolean> {
    // Backend tarafında doğrudan bir kontrol endpointi tanımlı değil.
    return false;
  }

  async getProfile(): Promise<ApiResponse<UserDto>> {
    try {
      const response = await api.get<ApiResponse<UserDto>>('/user');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<UserDto>(error);
    }
  }

  logout(): void {
    removeAuthToken();
  }
}