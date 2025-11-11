using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace cms_webapi.Services
{
    public class ProductPricingGroupByService : IProductPricingGroupByService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public ProductPricingGroupByService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<ProductPricingGroupByDto>>> GetAllProductPricingGroupBysAsync()
        {
            try
            {
                var productPricingGroupBys = await _unitOfWork.ProductPricingGroupBys.GetAllAsync();
                var productPricingGroupByDtos = _mapper.Map<List<ProductPricingGroupByDto>>(productPricingGroupBys);

                return ApiResponse<List<ProductPricingGroupByDto>>.SuccessResult(productPricingGroupByDtos,_localizationService.GetLocalizedString("ProductPricingGroupBysRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<ProductPricingGroupByDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ProductPricingGroupByDto>> GetProductPricingGroupByByIdAsync(int id)
        {
            try
            {
                var productPricingGroupBy = await _unitOfWork.ProductPricingGroupBys.GetByIdAsync(id);
                if (productPricingGroupBy == null)
                {
                    return ApiResponse<ProductPricingGroupByDto>.ErrorResult(_localizationService.GetLocalizedString("ProductPricingGroupByNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var productPricingGroupByDto = _mapper.Map<ProductPricingGroupByDto>(productPricingGroupBy);
                return ApiResponse<ProductPricingGroupByDto>.SuccessResult(productPricingGroupByDto, _localizationService.GetLocalizedString("ProductPricingGroupByRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductPricingGroupByDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ProductPricingGroupByDto>> CreateProductPricingGroupByAsync(CreateProductPricingGroupByDto createDto)
        {
            try
            {
                var productPricingGroupBy = _mapper.Map<ProductPricingGroupBy>(createDto);
                productPricingGroupBy.CreatedDate = DateTime.UtcNow;
                productPricingGroupBy.IsDeleted = false;

                await _unitOfWork.ProductPricingGroupBys.AddAsync(productPricingGroupBy);
                await _unitOfWork.SaveChangesAsync();

                var productPricingGroupByDto = _mapper.Map<ProductPricingGroupByDto>(productPricingGroupBy);
                return ApiResponse<ProductPricingGroupByDto>.SuccessResult(productPricingGroupByDto, _localizationService.GetLocalizedString("ProductPricingGroupByCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductPricingGroupByDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ProductPricingGroupByDto>> UpdateProductPricingGroupByAsync(int id, UpdateProductPricingGroupByDto updateDto)
        {
            try
            {
                var existingProductPricingGroupBy = await _unitOfWork.ProductPricingGroupBys.GetByIdAsync(id);
                if (existingProductPricingGroupBy == null)
                {
                    return ApiResponse<ProductPricingGroupByDto>.ErrorResult(_localizationService.GetLocalizedString("ProductPricingGroupByNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(updateDto, existingProductPricingGroupBy);
                existingProductPricingGroupBy.UpdatedDate = DateTime.UtcNow;

                await _unitOfWork.ProductPricingGroupBys.UpdateAsync(existingProductPricingGroupBy);
                await _unitOfWork.SaveChangesAsync();

                var productPricingGroupByDto = _mapper.Map<ProductPricingGroupByDto>(existingProductPricingGroupBy);
                return ApiResponse<ProductPricingGroupByDto>.SuccessResult(productPricingGroupByDto, _localizationService.GetLocalizedString("ProductPricingGroupByUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductPricingGroupByDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteProductPricingGroupByAsync(int id)
        {
            try
            {
                var productPricingGroupBy = await _unitOfWork.ProductPricingGroupBys.GetByIdAsync(id);
                if (productPricingGroupBy == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("ProductPricingGroupByNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                productPricingGroupBy.IsDeleted = true;
                productPricingGroupBy.UpdatedDate = DateTime.UtcNow;

                await _unitOfWork.ProductPricingGroupBys.UpdateAsync(productPricingGroupBy);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("ProductPricingGroupByDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
