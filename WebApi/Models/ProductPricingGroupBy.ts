import { BaseEntity } from './BaseEntity';

export interface ProductPricingGroupBy extends BaseEntity {
  erpGroupCode: string;
  currency: string;
  listPrice: number;
  costPrice: number;
  discount1?: number;
  discount2?: number;
  discount3?: number;
}