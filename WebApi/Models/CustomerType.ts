import { BaseEntity } from './BaseEntity';
import type { Customer } from './Customer';

export interface CustomerType extends BaseEntity {
  name: string;
  description?: string;
  customers?: Customer[];
}