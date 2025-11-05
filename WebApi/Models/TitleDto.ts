import type { ContactDto } from './ContactDto';

export interface TitleDto {
  id: number;
  titleName: string;
  createdDate: string;
  updatedDate?: string;
  contacts?: ContactDto[];
}

export interface CreateTitleDto {
  titleName: string;
}

export interface UpdateTitleDto {
  titleName: string;
}