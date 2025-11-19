using cms_webapi.DTOs;
using cms_webapi.Data;

namespace cms_webapi.Interfaces
{
    public interface IProductPricingService
    {
        Task<ApiResponse<List<ProductPricingDto>>> GetAllProductPricingsAsync();
        Task<ApiResponse<ProductPricingDto>> GetProductPricingByIdAsync(long id);
        Task<ApiResponse<ProductPricingDto>> CreateProductPricingAsync(CreateProductPricingDto createProductPricingDto);
        Task<ApiResponse<ProductPricingDto>> UpdateProductPricingAsync(long id, UpdateProductPricingDto updateProductPricingDto);
        Task<ApiResponse<object>> DeleteProductPricingAsync(long id);
    }
}
