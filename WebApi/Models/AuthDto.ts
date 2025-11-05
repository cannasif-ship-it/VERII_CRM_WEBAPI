import type { UserDto } from './UserDto';

export interface LoginDto {
  usernameOrEmail: string;
  password: string;
}

export interface LoginResponseDto {
  token: string;
  expiresAt: string;
  user: UserDto;
}

export interface RefreshTokenDto {
  token: string;
}