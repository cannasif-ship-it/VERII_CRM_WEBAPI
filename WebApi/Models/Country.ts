import { BaseEntity } from './BaseEntity';
import type { City } from './City';
import type { Contact } from './Contact';

export interface Country extends BaseEntity {
  name: string;
  code: string;
  erpCode?: string;
  cities?: City[];
  contacts?: Contact[];
}