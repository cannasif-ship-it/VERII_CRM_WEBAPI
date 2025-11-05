import { ApiResponse } from '../Models/ApiResponse';
import { PaymentTypeDto, CreatePaymentTypeDto, UpdatePaymentTypeDto } from '../Models/PaymentTypeDto';

export interface IPaymentTypeService {
  getAllPaymentTypes(): Promise<ApiResponse<PaymentTypeDto[]>>;
  getPaymentTypeById(id: number): Promise<ApiResponse<PaymentTypeDto>>;
  createPaymentType(createPaymentTypeDto: CreatePaymentTypeDto): Promise<ApiResponse<PaymentTypeDto>>;
  updatePaymentType(id: number, updatePaymentTypeDto: UpdatePaymentTypeDto): Promise<ApiResponse<PaymentTypeDto>>;
  deletePaymentType(id: number): Promise<ApiResponse<object>>;
}