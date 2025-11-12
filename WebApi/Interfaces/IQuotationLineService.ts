import { ApiResponse } from '../Models/ApiResponse';
import { QuotationLineDto, CreateQuotationLineDto, UpdateQuotationLineDto, QuotationLineGetDto } from '../Models/QuotationLineDto';

export interface IQuotationLineService {
  getAllQuotationLines(): Promise<ApiResponse<QuotationLineGetDto[]>>;
  getQuotationLineById(id: number): Promise<ApiResponse<QuotationLineGetDto>>;
  createQuotationLine(dto: CreateQuotationLineDto): Promise<ApiResponse<QuotationLineDto>>;
  updateQuotationLine(id: number, dto: UpdateQuotationLineDto): Promise<ApiResponse<QuotationLineDto>>;
  deleteQuotationLine(id: number): Promise<ApiResponse<object>>;
  getQuotationLinesByQuotationId(quotationId: number): Promise<ApiResponse<QuotationLineGetDto[]>>;
}