import type { CustomerGetDto } from './CustomerDto';
import type { ContactDto } from './ContactDto';
import type { UserDto } from './UserDto';

export interface ActivityDto {
  id: number;
  subject: string;
  description?: string;
  activityType: string;
  potentialCustomerId?: number;
  potentialCustomer?: CustomerGetDto;
  erpCustomerCode?: string;
  status: string;
  isCompleted: boolean;
  priority?: string;
  contactId?: number;
  contact?: ContactDto;
  assignedUserId?: number;
  assignedUser?: UserDto;
  createdDate: string;
  updatedDate?: string;
  isDeleted: boolean;
}

export interface CreateActivityDto {
  subject: string;
  description?: string;
  activityType: string;
  potentialCustomerId?: number;
  erpCustomerCode?: string;
  status: string;
  isCompleted?: boolean;
  priority?: string;
  contactId?: number;
  assignedUserId?: number;
}

export interface UpdateActivityDto {
  subject: string;
  description?: string;
  activityType: string;
  potentialCustomerId?: number;
  erpCustomerCode?: string;
  status: string;
  isCompleted?: boolean;
  priority?: string;
  contactId?: number;
  assignedUserId?: number;
}