import { IGenericRepository } from './IGenericRepository';
import { BaseEntity } from '../Models/BaseEntity';
import { User } from '../Models/User';
import { Country } from '../Models/Country';
import { City } from '../Models/City';
import { District } from '../Models/District';
import { CustomerType } from '../Models/CustomerType';
import { Customer } from '../Models/Customer';
import { Title } from '../Models/Title';
import { Contact } from '../Models/Contact';
import { Activity } from '../Models/Activity';
import { ProductPricing } from '../Models/ProductPricing';
import { ProductPricingGroupBy } from '../Models/ProductPricingGroupBy';
import { UserDiscountLimit } from '../Models/UserDiscountLimit';
import { PaymentType } from '../Models/PaymentType';
import { ShippingAddress } from '../Models/ShippingAddress';
import { Quotation } from '../Models/Quotation';

export interface IUnitOfWork {
  users: IGenericRepository<User>;
  countries: IGenericRepository<Country>;
  cities: IGenericRepository<City>;
  districts: IGenericRepository<District>;
  customerTypes: IGenericRepository<CustomerType>;
  customers: IGenericRepository<Customer>;
  titles: IGenericRepository<Title>;
  contacts: IGenericRepository<Contact>;
  activities: IGenericRepository<Activity>;
  productPricings: IGenericRepository<ProductPricing>;
  productPricingGroupBys: IGenericRepository<ProductPricingGroupBy>;
  userDiscountLimits: IGenericRepository<UserDiscountLimit>;
  paymentTypes: IGenericRepository<PaymentType>;
  shippingAddresses: IGenericRepository<ShippingAddress>;
  quotations: IGenericRepository<Quotation>;

  saveChanges(): Promise<number>;
  beginTransaction(): Promise<void>;
  commitTransaction(): Promise<void>;
  rollbackTransaction(): Promise<void>;
  repository<T extends BaseEntity>(): IGenericRepository<T>;
}