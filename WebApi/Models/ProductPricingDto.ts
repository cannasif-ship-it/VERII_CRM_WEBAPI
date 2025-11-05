export interface ProductPricingDto {
  id: number;
  erpProductCode: string;
  erpGroupCode: string;
  listPrice: number;
  costPrice: number;
  discount1?: number;
  discount2?: number;
  discount3?: number;
  createdDate: string;
  updatedDate?: string;
  deletedDate?: string;
  isDeleted: boolean;
}

export interface CreateProductPricingDto {
  erpProductCode: string;
  erpGroupCode: string;
  listPrice: number;
  costPrice: number;
  discount1?: number;
  discount2?: number;
  discount3?: number;
}

export interface UpdateProductPricingDto {
  erpProductCode: string;
  erpGroupCode: string;
  listPrice: number;
  costPrice: number;
  discount1?: number;
  discount2?: number;
  discount3?: number;
}