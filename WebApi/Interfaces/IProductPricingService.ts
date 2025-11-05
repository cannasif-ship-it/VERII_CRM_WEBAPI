import { ApiResponse } from '../Models/ApiResponse';
import { ProductPricingDto, CreateProductPricingDto, UpdateProductPricingDto } from '../Models/ProductPricingDto';

export interface IProductPricingService {
  getAllProductPricings(): Promise<ApiResponse<ProductPricingDto[]>>;
  getProductPricingById(id: number): Promise<ApiResponse<ProductPricingDto>>;
  createProductPricing(createProductPricingDto: CreateProductPricingDto): Promise<ApiResponse<ProductPricingDto>>;
  updateProductPricing(id: number, updateProductPricingDto: UpdateProductPricingDto): Promise<ApiResponse<ProductPricingDto>>;
  deleteProductPricing(id: number): Promise<ApiResponse<object>>;
}