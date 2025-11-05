import { BaseEntity } from './BaseEntity';
import type { Customer } from './Customer';
import type { Country } from './Country';
import type { City } from './City';
import type { District } from './District';

export interface ShippingAddress extends BaseEntity {
  address: string;
  postalCode?: string;
  contactPerson?: string;
  phone?: string;
  notes?: string;

  customerId: number;
  customer: Customer;

  countryId?: number;
  cityId?: number;
  districtId?: number;

  countries?: Country;
  cities?: City;
  districts?: District;
}