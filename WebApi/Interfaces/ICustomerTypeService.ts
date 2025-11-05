import { ApiResponse } from '../Models/ApiResponse';
import { CustomerTypeGetDto, CustomerTypeCreateDto, CustomerTypeUpdateDto } from '../Models/CustomerTypeDto';

export interface ICustomerTypeService {
  getAllCustomerTypes(): Promise<ApiResponse<CustomerTypeGetDto[]>>;
  getCustomerTypeById(id: number): Promise<ApiResponse<CustomerTypeGetDto>>;
  createCustomerType(customerTypeCreateDto: CustomerTypeCreateDto): Promise<ApiResponse<CustomerTypeGetDto>>;
  updateCustomerType(id: number, customerTypeUpdateDto: CustomerTypeUpdateDto): Promise<ApiResponse<CustomerTypeGetDto>>;
  deleteCustomerType(id: number): Promise<ApiResponse<object>>;
}