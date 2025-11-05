import axios, { AxiosRequestConfig } from 'axios';
import { ApiResponseErrorHelper } from '../ApiResponseErrorHelper';
import { API_BASE_URL, DEFAULT_TIMEOUT, CURRENTLANGUAGE, getAuthToken } from '../baseUrl';
import { IContactService } from '../Interfaces/IContactService';
import { ApiResponse } from '../Models/ApiResponse';
import { ContactDto, CreateContactDto, UpdateContactDto } from '../Models/ContactDto';

const api = axios.create({
  baseURL: API_BASE_URL + '/Contact',
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

export class ContactService implements IContactService {
  async getAllContacts(): Promise<ApiResponse<ContactDto[]>> {
    try {
      const response = await api.get<ApiResponse<ContactDto[]>>('/');
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ContactDto[]>(error);
    }
  }
  async getContactById(id: number): Promise<ApiResponse<ContactDto>> {
    try {
      const response = await api.get<ApiResponse<ContactDto>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ContactDto>(error);
    }
  }
  async createContact(dto: CreateContactDto): Promise<ApiResponse<ContactDto>> {
    try {
      const response = await api.post<ApiResponse<ContactDto>>('/', dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ContactDto>(error);
    }
  }
  async updateContact(id: number, dto: UpdateContactDto): Promise<ApiResponse<ContactDto>> {
    try {
      const response = await api.put<ApiResponse<ContactDto>>(`/${id}`, dto);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<ContactDto>(error);
    }
  }
  async deleteContact(id: number): Promise<ApiResponse<object>> {
    try {
      const response = await api.delete<ApiResponse<object>>(`/${id}`);
      return response.data;
    } catch (error) {
      return ApiResponseErrorHelper.create<object>(error);
    }
  }
}