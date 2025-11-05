import { ApiResponse } from '../Models/ApiResponse';
import { UserDiscountLimitDto, CreateUserDiscountLimitDto, UpdateUserDiscountLimitDto } from '../Models/UserDiscountLimitDto';

export interface IUserDiscountLimitService {
  getAll(): Promise<ApiResponse<UserDiscountLimitDto[]>>;
  getById(id: number): Promise<ApiResponse<UserDiscountLimitDto>>;
  getBySalespersonId(salespersonId: number): Promise<ApiResponse<UserDiscountLimitDto[]>>;
  getByErpProductGroupCode(erpProductGroupCode: string): Promise<ApiResponse<UserDiscountLimitDto[]>>;
  getBySalespersonAndGroup(salespersonId: number, erpProductGroupCode: string): Promise<ApiResponse<UserDiscountLimitDto>>;
  create(createDto: CreateUserDiscountLimitDto): Promise<ApiResponse<UserDiscountLimitDto>>;
  update(id: number, updateDto: UpdateUserDiscountLimitDto): Promise<ApiResponse<UserDiscountLimitDto>>;
  delete(id: number): Promise<ApiResponse<object>>;
  exists(id: number): Promise<ApiResponse<boolean>>;
  existsBySalespersonAndGroup(salespersonId: number, erpProductGroupCode: string): Promise<ApiResponse<boolean>>;
}