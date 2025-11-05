import { BaseEntity } from './BaseEntity';

export interface PaymentType extends BaseEntity {
  name: string;
  description?: string;
}