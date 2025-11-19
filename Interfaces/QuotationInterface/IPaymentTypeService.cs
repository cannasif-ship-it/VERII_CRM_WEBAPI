using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    public interface IPaymentTypeService
    {
        Task<ApiResponse<List<PaymentTypeDto>>> GetAllPaymentTypesAsync();
        Task<ApiResponse<PaymentTypeDto>> GetPaymentTypeByIdAsync(long id);
        Task<ApiResponse<PaymentTypeDto>> CreatePaymentTypeAsync(CreatePaymentTypeDto createPaymentTypeDto);
        Task<ApiResponse<PaymentTypeDto>> UpdatePaymentTypeAsync(long id, UpdatePaymentTypeDto updatePaymentTypeDto);
        Task<ApiResponse<object>> DeletePaymentTypeAsync(long id);
    }
}
