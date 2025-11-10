import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IAuthService } from '../Interfaces/IAuthService';
import { ApiResponse } from '../Models/ApiResponse';
import { LoginDto, LoginResponseDto } from '../Models/AuthDto';
import { CreateUserDto, UserDto } from '../Models/UserDto';
import { User } from '../Models/User';

function buildHeaders(): Record<string, string> {
  const token = getAuthToken();
  const headers: Record<string, string> = {
    'Content-Type': 'application/json',
    Accept: 'application/json',
    'X-Language': CURRENTLANGUAGE,
  };
  if (token) headers['Authorization'] = `Bearer ${token}`;
  return headers;
}

async function requestJson<T>(url: string, init?: RequestInit): Promise<T> {
  const res = await fetch(url, init);
  const data = await res.json().catch(() => null);
  if (!res.ok) {
    const err = new Error((data && (data.message || data.error)) || res.statusText);
    // @ts-ignore attach status for helpers
    err.status = res.status;
    throw err;
  }
  return data as T;
}

function toUserFromLoginResponse(data: LoginResponseDto['user']): User {
  return {
    id: data.id,
    createdDate: data.createdDate,
    updatedDate: data.createdDate,
    deletedDate: undefined as any,
    isDeleted: data.isDeleted,
    username: data.username,
    email: data.email,
    passwordHash: '',
    firstName: data.firstName,
    lastName: data.lastName,
    phoneNumber: data.phoneNumber,
    roleId: 0,
    isEmailConfirmed: data.isEmailConfirmed,
    isActive: !data.isDeleted,
    fullName: data.fullName,
    lastLoginDate: data.lastLoginDate,
  } as User;
}

export class AuthService implements IAuthService {
  private baseUrl = `${API_BASE_URL}/Auth`;

  async login(loginDto: LoginDto): Promise<ApiResponse<LoginResponseDto>> {
    try {
      const data = await requestJson<ApiResponse<LoginResponseDto>>(`${this.baseUrl}/login`, {
        method: 'POST',
        headers: buildHeaders(),
        body: JSON.stringify(loginDto),
      });
      return data;
    } catch (error: any) {
      return ApiResponseErrorHelper.create<LoginResponseDto>(error);
    }
  }

  async register(createUserDto: CreateUserDto): Promise<ApiResponse<UserDto>> {
    try {
      const data = await requestJson<ApiResponse<UserDto>>(`${this.baseUrl}/register`, {
        method: 'POST',
        headers: buildHeaders(),
        body: JSON.stringify(createUserDto),
      });
      return data;
    } catch (error: any) {
      return ApiResponseErrorHelper.create<UserDto>(error);
    }
  }

  async validateUser(usernameOrEmail: string, password: string): Promise<User | null> {
    try {
      const payload: LoginDto = { usernameOrEmail, password };
      const data = await requestJson<ApiResponse<LoginResponseDto>>(`${this.baseUrl}/login`, {
        method: 'POST',
        headers: buildHeaders(),
        body: JSON.stringify(payload),
      });
      if (data.success && data.data) {
        return toUserFromLoginResponse(data.data.user);
      }
      return null;
    } catch {
      return null;
    }
  }

  async emailExists(email: string): Promise<boolean> {
    try {
      const data = await requestJson<ApiResponse<boolean>>(`${this.baseUrl}/email-exists?email=${encodeURIComponent(email)}`, {
        method: 'GET',
        headers: buildHeaders(),
      });
      return !!data.data;
    } catch {
      return false;
    }
  }

  async usernameExists(username: string): Promise<boolean> {
    try {
      const data = await requestJson<ApiResponse<boolean>>(`${this.baseUrl}/username-exists?username=${encodeURIComponent(username)}`, {
        method: 'GET',
        headers: buildHeaders(),
      });
      return !!data.data;
    } catch {
      return false;
    }
  }
}