import { ApiResponse } from '../Models/ApiResponse';
import { ContactDto, CreateContactDto, UpdateContactDto } from '../Models/ContactDto';

export interface IContactService {
  getAllContacts(): Promise<ApiResponse<ContactDto[]>>;
  getContactById(id: number): Promise<ApiResponse<ContactDto>>;
  createContact(createContactDto: CreateContactDto): Promise<ApiResponse<ContactDto>>;
  updateContact(id: number, updateContactDto: UpdateContactDto): Promise<ApiResponse<ContactDto>>;
  deleteContact(id: number): Promise<ApiResponse<object>>;
}