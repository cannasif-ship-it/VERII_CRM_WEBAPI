import { ApiResponse } from '../Models/ApiResponse';
import { LoginDto, LoginResponseDto } from '../Models/AuthDto';
import { CreateUserDto, UserDto } from '../Models/UserDto';
import { User } from '../Models/User';

export interface IAuthService {
  login(loginDto: LoginDto): Promise<ApiResponse<LoginResponseDto>>;
  register(createUserDto: CreateUserDto): Promise<ApiResponse<UserDto>>;
  validateUser(usernameOrEmail: string, password: string): Promise<User | null>;
  emailExists(email: string): Promise<boolean>;
  usernameExists(username: string): Promise<boolean>;
}