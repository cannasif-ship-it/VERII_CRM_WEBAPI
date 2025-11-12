import { ApiResponse } from '../Models/ApiResponse';
import { User } from '../Models/User';
import { removeAuthToken } from '../baseUrl';

export class JwtService {
  async generateToken(user: User): Promise<ApiResponse<string>> {
    return {
      success: false,
      message: 'generateToken desteklenmiyor: Lütfen AuthService.login kullanın',
      exceptionMessage: 'NotImplemented',
      data: undefined,
      errors: [],
      timestamp: new Date().toISOString(),
      statusCode: 501,
      className: 'ApiResponse'
    };
  }

  async refreshToken(): Promise<ApiResponse<string>> {
    return {
      success: false,
      message: 'refreshToken endpointi tanımlı değil',
      exceptionMessage: 'NotImplemented',
      data: undefined,
      errors: [],
      timestamp: new Date().toISOString(),
      statusCode: 501,
      className: 'ApiResponse'
    };
  }

  logout(): void {
    removeAuthToken();
  }
}