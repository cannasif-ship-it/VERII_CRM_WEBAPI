export interface CustomerTypeGetDto {
  name: string;
  description?: string;
  createdDate: string;
  updatedDate?: string;
  createdByFullUser?: string;
  updatedByFullUser?: string;
  deletedByFullUser?: string;
}

export interface CustomerTypeCreateDto {
  name: string;
  description?: string;
}

export interface CustomerTypeUpdateDto {
  name: string;
  description?: string;
}