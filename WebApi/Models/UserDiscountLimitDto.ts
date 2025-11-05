export interface UserDiscountLimitDto {
  id: number;
  erpProductGroupCode: string;
  salespersonId: number;
  salespersonName: string;
  maxDiscount1: number;
  maxDiscount2?: number;
  maxDiscount3?: number;
  createdDate: string;
  updatedDate?: string;
  deletedDate?: string;
  isDeleted: boolean;
  createdBy?: number;
  updatedBy?: number;
  deletedBy?: number;
}

export interface CreateUserDiscountLimitDto {
  erpProductGroupCode: string;
  salespersonId: number;
  maxDiscount1: number;
  maxDiscount2?: number;
  maxDiscount3?: number;
}

export interface UpdateUserDiscountLimitDto {
  erpProductGroupCode: string;
  salespersonId: number;
  maxDiscount1: number;
  maxDiscount2?: number;
  maxDiscount3?: number;
}