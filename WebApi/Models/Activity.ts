import { BaseEntity } from './BaseEntity';
import type { Customer } from './Customer';
import type { Contact } from './Contact';
import type { User } from './User';

export interface Activity extends BaseEntity {
  subject: string;
  description?: string;
  activityType: string;
  potentialCustomerId?: number;
  potentialCustomer?: Customer;
  erpCustomerCode?: string;
  status: string;
  isCompleted: boolean;
  priority?: string;
  contactId?: number;
  contact?: Contact;
  assignedUserId?: number;
  assignedUser?: User;
}