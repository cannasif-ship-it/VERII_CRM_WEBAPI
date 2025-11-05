import { BaseHeaderEntity } from './BaseHeaderEntity';
import type { Country } from './Country';
import type { City } from './City';
import type { District } from './District';
import type { CustomerType } from './CustomerType';

export interface Customer extends BaseHeaderEntity {
  // Basic Information
  customerCode?: string;
  customerName: string;
  customerTypeId?: number;

  // Tax Information
  taxOffice?: string;
  taxNumber?: string;

  // Classification
  salesRepCode?: string;
  groupCode?: string;

  // Financial Information
  creditLimit?: number;

  // ERP Integration
  branchCode: number;
  businessUnitCode: number;

  // Contact Information
  notes?: string;
  email?: string;
  website?: string;
  phone1?: string;
  phone2?: string;
  address?: string;

  // Location Information
  countryId?: number;
  cityId?: number;
  districtId?: number;

  // Navigation Properties
  countries?: Country;
  cities?: City;
  districts?: District;
  customerTypes?: CustomerType;
}