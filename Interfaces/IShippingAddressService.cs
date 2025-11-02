using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    public interface IShippingAddressService
    {
        Task<ApiResponse<List<ShippingAddressGetDto>>> GetAllShippingAddressesAsync();
        Task<ApiResponse<ShippingAddressGetDto>> GetShippingAddressByIdAsync(long id);
        Task<ApiResponse<List<ShippingAddressGetDto>>> GetShippingAddressesByCustomerIdAsync(long customerId);
        Task<ApiResponse<ShippingAddressGetDto>> CreateShippingAddressAsync(CreateShippingAddressDto createShippingAddressDto);
        Task<ApiResponse<ShippingAddressGetDto>> UpdateShippingAddressAsync(long id, UpdateShippingAddressDto updateShippingAddressDto);
        Task<ApiResponse<object>> DeleteShippingAddressAsync(long id);
    }
}
