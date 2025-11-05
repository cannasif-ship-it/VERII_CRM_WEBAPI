export interface CityGetDto {
  id: number;
  name: string;
  erpCode?: string;
  countryId: number;
  countryName?: string;
  createdDate: string;
  updatedDate?: string;
  createdByFullUser?: string;
  updatedByFullUser?: string;
  deletedByFullUser?: string;
}

export interface CityCreateDto {
  name: string;
  erpCode?: string;
  countryId: number;
}

export interface CityUpdateDto {
  name: string;
  erpCode?: string;
  countryId: number;
}