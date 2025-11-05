import { BaseEntity } from './BaseEntity';

export interface ProductPricing extends BaseEntity {
  erpProductCode: string;
  erpGroupCode: string;
  currency: string;
  listPrice: number;
  costPrice: number;
  discount1?: number;
  discount2?: number;
  discount3?: number;
}