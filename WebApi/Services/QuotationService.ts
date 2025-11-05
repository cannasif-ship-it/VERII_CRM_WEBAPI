import axios, { AxiosRequestConfig } from 'axios';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IQuotationService } from '../Interfaces/IQuotationService';
import { QuotationDto, CreateQuotationDto, UpdateQuotationDto, QuotationGetDto } from '../Models/QuotationDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/Quotation',
  timeout: DEFAULT_TIMEOUT,
  headers: {
    'Content-Type': 'application/json',
    Accept: 'application/json',
    'X-Language': CURRENTLANGUAGE,
  },
});

api.interceptors.request.use((config: AxiosRequestConfig) => {
  const token = getAuthToken();
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

export class QuotationService implements IQuotationService {
  async getAllQuotations(): Promise<QuotationGetDto[]> {
    try {
      const response = await api.get<QuotationGetDto[]>('/');
      return response.data;
    } catch (error) {
      return [];
    }
  }

  async getQuotationById(id: number): Promise<QuotationGetDto | null> {
    try {
      const response = await api.get<QuotationGetDto>(`/${id}`);
      return response.data;
    } catch (error) {
      return null;
    }
  }

  async createQuotation(dto: CreateQuotationDto): Promise<QuotationDto> {
    const response = await api.post<QuotationDto>('/', dto);
    return response.data;
  }

  async updateQuotation(id: number, dto: UpdateQuotationDto): Promise<QuotationDto | null> {
    try {
      const response = await api.put<QuotationDto>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return null;
    }
  }

  async deleteQuotation(id: number): Promise<boolean> {
    try {
      const response = await api.delete<boolean>(`/${id}`);
      return response.data;
    } catch (error) {
      return false;
    }
  }

  async getQuotationsByPotentialCustomerId(potentialCustomerId: number): Promise<QuotationGetDto[]> {
    try {
      const response = await api.get<QuotationGetDto[]>(`/by-potential-customer/${potentialCustomerId}`);
      return response.data;
    } catch {
      return [];
    }
  }

  async getQuotationsByRepresentativeId(representativeId: number): Promise<QuotationGetDto[]> {
    try {
      const response = await api.get<QuotationGetDto[]>(`/by-representative/${representativeId}`);
      return response.data;
    } catch {
      return [];
    }
  }

  async getQuotationsByStatus(status: number): Promise<QuotationGetDto[]> {
    try {
      const response = await api.get<QuotationGetDto[]>(`/by-status/${status}`);
      return response.data;
    } catch {
      return [];
    }
  }

  async quotationExists(id: number): Promise<boolean> {
    try {
      const response = await api.get<boolean>(`/${id}/exists`);
      return response.data;
    } catch {
      return false;
    }
  }
}