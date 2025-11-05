import { ApiResponse } from '../Models/ApiResponse';
import { ProductPricingGroupByDto, CreateProductPricingGroupByDto, UpdateProductPricingGroupByDto } from '../Models/ProductPricingGroupByDto';

export interface IProductPricingGroupByService {
  getAllProductPricingGroupBys(): Promise<ApiResponse<ProductPricingGroupByDto[]>>;
  getProductPricingGroupByById(id: number): Promise<ApiResponse<ProductPricingGroupByDto>>;
  createProductPricingGroupBy(createDto: CreateProductPricingGroupByDto): Promise<ApiResponse<ProductPricingGroupByDto>>;
  updateProductPricingGroupBy(id: number, updateDto: UpdateProductPricingGroupByDto): Promise<ApiResponse<ProductPricingGroupByDto>>;
  deleteProductPricingGroupBy(id: number): Promise<ApiResponse<object>>;
}