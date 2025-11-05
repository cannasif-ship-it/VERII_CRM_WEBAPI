import { ApiResponse, PagedResponse } from '../Models/ApiResponse';
import { UserDto, CreateUserDto, UpdateUserDto } from '../Models/UserDto';

export interface IUserService {
  getAllUsers(): Promise<ApiResponse<UserDto[]>>;
  getUserById(id: number): Promise<ApiResponse<UserDto>>;
  createUser(createUserDto: CreateUserDto): Promise<ApiResponse<UserDto>>;
  updateUser(id: number, updateUserDto: UpdateUserDto): Promise<ApiResponse<UserDto>>;
  deleteUser(id: number): Promise<ApiResponse<object>>;
  getUsersPaged(pageNumber: number, pageSize: number): Promise<ApiResponse<PagedResponse<UserDto>>>;
  userExists(username: string, email: string): Promise<boolean>;
  isEmailTakenByAnotherUser(email: string, excludeUserId: number): Promise<boolean>;
}