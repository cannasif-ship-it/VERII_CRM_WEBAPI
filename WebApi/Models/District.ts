import { BaseEntity } from './BaseEntity';
import type { City } from './City';

export interface District extends BaseEntity {
  name: string;
  erpCode?: string;
  cityId: number;
  city: City;
}