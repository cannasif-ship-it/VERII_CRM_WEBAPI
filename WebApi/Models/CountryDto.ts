export interface CountryGetDto {
  id: number;
  name: string;
  code: string;
  erpCode?: string;
  createdDate: string;
  updatedDate?: string;
  createdByFullUser?: string;
  updatedByFullUser?: string;
  deletedByFullUser?: string;
}

export interface CountryCreateDto {
  name: string;
  code: string;
  erpCode?: string;
}

export interface CountryUpdateDto {
  name: string;
  code: string;
  erpCode?: string;
}