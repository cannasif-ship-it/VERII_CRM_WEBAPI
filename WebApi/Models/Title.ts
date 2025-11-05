import { BaseEntity } from './BaseEntity';
import type { Contact } from './Contact';

export interface Title extends BaseEntity {
  titleName: string;
  code?: string;
  contacts?: Contact[];
}