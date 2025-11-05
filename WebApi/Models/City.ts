import { BaseEntity } from './BaseEntity';
import type { Country } from './Country';
import type { District } from './District';

export interface City extends BaseEntity {
  name: string;
  erpCode?: string;
  countryId: number;
  country: Country;
  districts?: District[];
}