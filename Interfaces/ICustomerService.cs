using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    public interface ICustomerService
    {
        Task<ApiResponse<List<CustomerGetDto>>> GetAllCustomersAsync();
        Task<ApiResponse<CustomerGetDto>> GetCustomerByIdAsync(long id);
        Task<ApiResponse<CustomerGetDto>> CreateCustomerAsync(CustomerCreateDto customerCreateDto);
        Task<ApiResponse<CustomerGetDto>> UpdateCustomerAsync(long id, CustomerUpdateDto customerUpdateDto);
        Task<ApiResponse<object>> DeleteCustomerAsync(long id);
    }
}
