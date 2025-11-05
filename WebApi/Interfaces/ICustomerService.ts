import { ApiResponse } from '../Models/ApiResponse';
import { CustomerGetDto, CustomerCreateDto, CustomerUpdateDto } from '../Models/CustomerDto';

export interface ICustomerService {
  getAllCustomers(): Promise<ApiResponse<CustomerGetDto[]>>;
  getCustomerById(id: number): Promise<ApiResponse<CustomerGetDto>>;
  createCustomer(customerCreateDto: CustomerCreateDto): Promise<ApiResponse<CustomerGetDto>>;
  updateCustomer(id: number, customerUpdateDto: CustomerUpdateDto): Promise<ApiResponse<CustomerGetDto>>;
  deleteCustomer(id: number): Promise<ApiResponse<object>>;
}