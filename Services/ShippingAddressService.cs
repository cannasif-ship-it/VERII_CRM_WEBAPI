using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace cms_webapi.Services
{
    public class ShippingAddressService : IShippingAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public ShippingAddressService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<ShippingAddressGetDto>>> GetAllShippingAddressesAsync()
        {
            try
            {
                var shippingAddresses = await _unitOfWork.ShippingAddresses.GetAllAsync();

                var shippingAddressDtos = _mapper.Map<List<ShippingAddressGetDto>>(shippingAddresses);

                return ApiResponse<List<ShippingAddressGetDto>>.SuccessResult(shippingAddressDtos, _localizationService.GetLocalizedString("ShippingAddressesRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<ShippingAddressGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ShippingAddressGetDto>> GetShippingAddressByIdAsync(long id)
        {
            try
            {
                var shippingAddress = await _unitOfWork.ShippingAddresses.GetByIdAsync(id);

                if (shippingAddress == null)
                {
                    return ApiResponse<ShippingAddressGetDto>.ErrorResult(_localizationService.GetLocalizedString("ShippingAddressNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var shippingAddressDto = _mapper.Map<ShippingAddressGetDto>(shippingAddress);

                return ApiResponse<ShippingAddressGetDto>.SuccessResult(shippingAddressDto, _localizationService.GetLocalizedString("ShippingAddressRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ShippingAddressGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<List<ShippingAddressGetDto>>> GetShippingAddressesByCustomerIdAsync(long customerId)
        {
            try
            {
                var shippingAddresses = await _unitOfWork.ShippingAddresses.FindAsync(sa => sa.CustomerId == customerId);

                var shippingAddressDtos = _mapper.Map<List<ShippingAddressGetDto>>(shippingAddresses);

                return ApiResponse<List<ShippingAddressGetDto>>.SuccessResult(shippingAddressDtos, _localizationService.GetLocalizedString("ShippingAddressesByCustomerRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<ShippingAddressGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ShippingAddressGetDto>> CreateShippingAddressAsync(CreateShippingAddressDto createShippingAddressDto)
        {
            try
            {
                var shippingAddress = _mapper.Map<ShippingAddress>(createShippingAddressDto);

                await _unitOfWork.ShippingAddresses.AddAsync(shippingAddress);
                await _unitOfWork.SaveChangesAsync();

                var createdShippingAddress = await _unitOfWork.ShippingAddresses.GetByIdAsync(shippingAddress.Id);

                var shippingAddressDto = _mapper.Map<ShippingAddressGetDto>(createdShippingAddress);

                return ApiResponse<ShippingAddressGetDto>.SuccessResult(shippingAddressDto, _localizationService.GetLocalizedString("ShippingAddressCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ShippingAddressGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ShippingAddressGetDto>> UpdateShippingAddressAsync(long id, UpdateShippingAddressDto updateShippingAddressDto)
        {
            try
            {
                var existingShippingAddress = await _unitOfWork.ShippingAddresses.GetByIdAsync(id);

                if (existingShippingAddress == null)
                {
                    return ApiResponse<ShippingAddressGetDto>.ErrorResult(_localizationService.GetLocalizedString("ShippingAddressNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(updateShippingAddressDto, existingShippingAddress);
                existingShippingAddress.UpdatedDate = DateTime.UtcNow;

               await _unitOfWork.ShippingAddresses.UpdateAsync(existingShippingAddress);
                await _unitOfWork.SaveChangesAsync();

                var updatedShippingAddress = await _unitOfWork.ShippingAddresses.GetByIdAsync(id);

                var shippingAddressDto = _mapper.Map<ShippingAddressGetDto>(updatedShippingAddress);

                return ApiResponse<ShippingAddressGetDto>.SuccessResult(shippingAddressDto, _localizationService.GetLocalizedString("ShippingAddressUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ShippingAddressGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteShippingAddressAsync(long id)
        {
            try
            {
                var shippingAddress = await _unitOfWork.ShippingAddresses.GetByIdAsync(id);

                if (shippingAddress == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("ShippingAddressNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                shippingAddress.DeletedDate = DateTime.UtcNow;

                await _unitOfWork.ShippingAddresses.UpdateAsync(shippingAddress);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("ShippingAddressDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
