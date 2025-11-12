export interface QuotationLineDto {
  id: number;
  quotationId: number;
  productId?: number;
  productCode?: string;
  productName: string;
  quantity: number;
  unitPrice: number;
  discountRate1: number;
  discountAmount1: number;
  discountRate2: number;
  discountAmount2: number;
  discountRate3: number;
  discountAmount3: number;
  vatRate: number;
  vatAmount: number;
  lineTotal: number;
  lineGrandTotal: number;
  description?: string;
  createdDate: string;
  updatedDate?: string;
}

export interface CreateQuotationLineDto {
  quotationId: number;
  productId?: number;
  productCode?: string;
  productName?: string;
  quantity: number;
  unitPrice: number;
  discountRate1: number;
  discountAmount1: number;
  discountRate2: number;
  discountAmount2: number;
  discountRate3: number;
  discountAmount3: number;
  vatRate: number;
  vatAmount: number;
  lineTotal: number;
  lineGrandTotal: number;
  description?: string;
}

export interface UpdateQuotationLineDto {
  productId: number;
  productCode?: string;
  productName?: string;
  quantity: number;
  unitPrice: number;
  discountRate1: number;
  discountAmount1: number;
  discountRate2: number;
  discountAmount2: number;
  discountRate3: number;
  discountAmount3: number;
  vatRate: number;
  vatAmount: number;
  lineTotal: number;
  lineGrandTotal: number;
  description?: string;
}

export interface QuotationLineGetDto extends QuotationLineDto {}