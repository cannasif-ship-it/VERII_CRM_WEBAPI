import { BaseEntity } from './BaseEntity';
import type { User } from './User';

export interface UserDiscountLimit extends BaseEntity {
  erpProductGroupCode: string;
  salespersonId: number;
  salespersons: User;

  maxDiscount1: number;
  maxDiscount2?: number;
  maxDiscount3?: number;
}