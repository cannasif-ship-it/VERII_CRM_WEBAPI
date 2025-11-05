import { BaseHeaderEntity } from './BaseHeaderEntity';
import type { Customer } from './Customer';
import type { ShippingAddress } from './ShippingAddress';
import type { User } from './User';
import type { PaymentType } from './PaymentType';

export interface Quotation extends BaseHeaderEntity {
  potentialCustomerId?: number;
  potentialCustomer?: Customer;

  erpCustomerCode?: string;
  deliveryDate?: string;

  shippingAddressId?: number;
  shippingAddress?: ShippingAddress;

  representativeId?: number;
  representative?: User;

  status?: number;
  description?: string;

  paymentTypeId?: number;
  paymentType?: PaymentType;

  offerType: string;
  offerDate?: string;
  offerNo?: string;
  revisionNo?: string;
  revisionId?: number;

  currency: string;
  exchangeRate?: number;
}