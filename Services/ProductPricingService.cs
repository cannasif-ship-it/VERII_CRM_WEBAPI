using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;

namespace cms_webapi.Services
{
    public class ProductPricingService : IProductPricingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public ProductPricingService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<ProductPricingDto>>> GetAllProductPricingsAsync()
        {
            try
            {
                var productPricings = await _unitOfWork.ProductPricings.GetAllAsync();
                var productPricingDtos = _mapper.Map<List<ProductPricingDto>>(productPricings);

                return ApiResponse<List<ProductPricingDto>>.SuccessResult(productPricingDtos, _localizationService.GetLocalizedString("ProductPricingsRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<ProductPricingDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ProductPricingDto>> GetProductPricingByIdAsync(long id)
        {
            try
            {
                var productPricing = await _unitOfWork.ProductPricings.GetByIdAsync(id);
                if (productPricing == null)
                {
                    return ApiResponse<ProductPricingDto>.ErrorResult(_localizationService.GetLocalizedString("ProductPricingNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var productPricingDto = _mapper.Map<ProductPricingDto>(productPricing);
                return ApiResponse<ProductPricingDto>.SuccessResult(productPricingDto, _localizationService.GetLocalizedString("ProductPricingRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductPricingDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ProductPricingDto>> CreateProductPricingAsync(CreateProductPricingDto createProductPricingDto)
        {
            try
            {
                var productPricing = _mapper.Map<ProductPricing>(createProductPricingDto);
                productPricing.CreatedDate = DateTime.UtcNow;

                await _unitOfWork.ProductPricings.AddAsync(productPricing);
                await _unitOfWork.SaveChangesAsync();

                var productPricingDto = _mapper.Map<ProductPricingDto>(productPricing);
                return ApiResponse<ProductPricingDto>.SuccessResult(productPricingDto, _localizationService.GetLocalizedString("ProductPricingCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductPricingDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ProductPricingDto>> UpdateProductPricingAsync(long id, UpdateProductPricingDto updateProductPricingDto)
        {
            try
            {
                var existingProductPricing = await _unitOfWork.ProductPricings.GetByIdAsync(id);
                if (existingProductPricing == null)
                {
                    return ApiResponse<ProductPricingDto>.ErrorResult(_localizationService.GetLocalizedString("ProductPricingNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(updateProductPricingDto, existingProductPricing);
                existingProductPricing.UpdatedDate = DateTime.UtcNow;

                await _unitOfWork.ProductPricings.UpdateAsync(existingProductPricing);
                await _unitOfWork.SaveChangesAsync();

                var productPricingDto = _mapper.Map<ProductPricingDto>(existingProductPricing);
                return ApiResponse<ProductPricingDto>.SuccessResult(productPricingDto, _localizationService.GetLocalizedString("ProductPricingUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductPricingDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteProductPricingAsync(long id)
        {
            try
            {
                var productPricing = await _unitOfWork.ProductPricings.GetByIdAsync(id);
                if (productPricing == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("ProductPricingNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                productPricing.IsDeleted = true;
                productPricing.DeletedDate = DateTime.UtcNow;

                await _unitOfWork.ProductPricings.UpdateAsync(productPricing);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("ProductPricingDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
