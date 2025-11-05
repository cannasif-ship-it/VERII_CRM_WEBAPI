export interface QuotationDto {
  id: number;
  potentialCustomerId?: number;
  potentialCustomerName?: string;
  erpCustomerCode?: string;
  deliveryDate?: string;
  shippingAddressId?: number;
  shippingAddressText?: string;
  representativeId?: number;
  representativeName?: string;
  status?: number;
  description?: string;
  paymentTypeId?: number;
  paymentTypeName?: string;
  offerType: string;
  offerDate?: string;
  offerNo?: string;
  revisionNo?: string;
  revisionId?: number;
  currency: string;
  exchangeRate?: number;
  createdDate: string;
  updatedDate?: string;
  createdBy?: string;
  updatedBy?: string;
}

export interface CreateQuotationDto {
  potentialCustomerId?: number;
  erpCustomerCode?: string;
  deliveryDate?: string;
  shippingAddressId?: number;
  representativeId?: number;
  status?: number;
  description?: string;
  paymentTypeId?: number;
  offerType: string;
  offerDate?: string;
  offerNo?: string;
  revisionNo?: string;
  revisionId?: number;
  currency: string;
  exchangeRate?: number;
}

export interface UpdateQuotationDto {
  potentialCustomerId?: number;
  erpCustomerCode?: string;
  deliveryDate?: string;
  shippingAddressId?: number;
  representativeId?: number;
  status?: number;
  description?: string;
  paymentTypeId?: number;
  offerType: string;
  offerDate?: string;
  offerNo?: string;
  revisionNo?: string;
  revisionId?: number;
  currency: string;
  exchangeRate?: number;
}

export interface QuotationGetDto {
  id: number;
  potentialCustomerId?: number;
  potentialCustomerName?: string;
  erpCustomerCode?: string;
  deliveryDate?: string;
  shippingAddressId?: number;
  shippingAddressText?: string;
  representativeId?: number;
  representativeName?: string;
  status?: number;
  description?: string;
  paymentTypeId?: number;
  paymentTypeName?: string;
  offerType: string;
  offerDate?: string;
  offerNo?: string;
  revisionNo?: string;
  revisionId?: number;
  currency: string;
  exchangeRate?: number;
  createdDate: string;
  updatedDate?: string;
  createdBy?: string;
  updatedBy?: string;
}