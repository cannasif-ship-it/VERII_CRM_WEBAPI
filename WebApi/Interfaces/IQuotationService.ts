import { QuotationDto, CreateQuotationDto, UpdateQuotationDto, QuotationGetDto } from '../Models/QuotationDto';

export interface IQuotationService {
  getAllQuotations(): Promise<QuotationGetDto[]>;
  getQuotationById(id: number): Promise<QuotationGetDto | null>;
  createQuotation(createQuotationDto: CreateQuotationDto): Promise<QuotationDto>;
  updateQuotation(id: number, updateQuotationDto: UpdateQuotationDto): Promise<QuotationDto | null>;
  deleteQuotation(id: number): Promise<boolean>;
  getQuotationsByPotentialCustomerId(potentialCustomerId: number): Promise<QuotationGetDto[]>;
  getQuotationsByRepresentativeId(representativeId: number): Promise<QuotationGetDto[]>;
  getQuotationsByStatus(status: number): Promise<QuotationGetDto[]>;
  quotationExists(id: number): Promise<boolean>;
}