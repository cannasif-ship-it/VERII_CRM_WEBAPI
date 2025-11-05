export interface DistrictGetDto {
  id: number;
  name: string;
  erpCode?: string;
  cityId: number;
  cityName?: string;
  createdDate: string;
  updatedDate?: string;
  createdByFullUser?: string;
  updatedByFullUser?: string;
  deletedByFullUser?: string;
}

export interface DistrictCreateDto {
  name: string;
  erpCode?: string;
  cityId: number;
}

export interface DistrictUpdateDto {
  name: string;
  erpCode?: string;
  cityId: number;
}