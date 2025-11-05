export interface CustomerGetDto {
  id: number;
  customerCode: string;
  name: string;
  taxNumber?: string;
  taxOffice?: string;
  address?: string;
  phone?: string;
  email?: string;
  website?: string;
  countryId: number;
  countryName?: string;
  cityId: number;
  cityName?: string;
  districtId: number;
  districtName?: string;
  customerTypeId: number;
  customerTypeName?: string;
  erpCode?: string;
  completedDate?: string;
  isCompleted: boolean;
  isApproved: boolean;
  isERPIntegrated: boolean;
  createdDate: string;
  updatedDate?: string;
  createdByFullUser?: string;
  updatedByFullUser?: string;
  deletedByFullUser?: string;
}

export interface CustomerCreateDto {
  customerCode: string;
  name: string;
  taxNumber?: string;
  taxOffice?: string;
  address?: string;
  phone?: string;
  email?: string;
  website?: string;
  countryId: number;
  cityId: number;
  districtId: number;
  customerTypeId: number;
  erpCode?: string;
  isCompleted?: boolean;
  isApproved?: boolean;
  isERPIntegrated?: boolean;
}

export interface CustomerUpdateDto {
  customerCode: string;
  name: string;
  taxNumber?: string;
  taxOffice?: string;
  address?: string;
  phone?: string;
  email?: string;
  website?: string;
  countryId: number;
  cityId: number;
  districtId: number;
  customerTypeId: number;
  erpCode?: string;
  completedDate?: string;
  isCompleted: boolean;
  isApproved: boolean;
  isERPIntegrated: boolean;
}