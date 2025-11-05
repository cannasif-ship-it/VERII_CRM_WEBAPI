import { ApiResponse } from '../Models/ApiResponse';
import { ShippingAddressGetDto, CreateShippingAddressDto, UpdateShippingAddressDto } from '../Models/ShippingAddressDto';

export interface IShippingAddressService {
  getAllShippingAddresses(): Promise<ApiResponse<ShippingAddressGetDto[]>>;
  getShippingAddressById(id: number): Promise<ApiResponse<ShippingAddressGetDto>>;
  getShippingAddressesByCustomerId(customerId: number): Promise<ApiResponse<ShippingAddressGetDto[]>>;
  createShippingAddress(createDto: CreateShippingAddressDto): Promise<ApiResponse<ShippingAddressGetDto>>;
  updateShippingAddress(id: number, updateDto: UpdateShippingAddressDto): Promise<ApiResponse<ShippingAddressGetDto>>;
  deleteShippingAddress(id: number): Promise<ApiResponse<object>>;
}