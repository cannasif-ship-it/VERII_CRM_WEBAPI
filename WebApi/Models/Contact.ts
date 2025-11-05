import { BaseEntity } from './BaseEntity';
import type { Customer } from './Customer';
import type { Title } from './Title';

export interface Contact extends BaseEntity {
  fullName: string;
  email?: string;
  phone?: string;
  mobile?: string;
  notes?: string;
  customerId: number;
  customers: Customer;
  titleId: number;
  titles: Title;
}