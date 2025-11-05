export interface PaymentTypeDto {
  id: number;
  name: string;
  description?: string;
  createdDate: string;
  updatedDate?: string;
  isActive: boolean;
  createdBy?: string;
  updatedBy?: string;
  createdByFullUser?: string;
  updatedByFullUser?: string;
  deletedByFullUser?: string;
}

export interface PaymentTypeGetDto {
  id: number;
  name: string;
  description?: string;
  createdDate: string;
  updatedDate?: string;
  isActive: boolean;
  createdBy?: string;
  updatedBy?: string;
  createdByFullUser?: string;
  updatedByFullUser?: string;
  deletedByFullUser?: string;
}

export interface CreatePaymentTypeDto {
  name: string;
  description?: string;
}

export interface UpdatePaymentTypeDto {
  id: number;
  name: string;
  description?: string;
}