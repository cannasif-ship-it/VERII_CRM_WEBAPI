using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    public interface IQuotationApprovalService
    {
        Task<ApiResponse<List<QuotationApprovalDto>>> GetAllQuotationApprovalsAsync();
        Task<ApiResponse<QuotationApprovalDto>> GetQuotationApprovalByIdAsync(long id);
        Task<ApiResponse<QuotationApprovalDto>> CreateQuotationApprovalAsync(CreateQuotationApprovalDto dto);
        Task<ApiResponse<QuotationApprovalDto>> UpdateQuotationApprovalAsync(long id, UpdateQuotationApprovalDto dto);
        Task<ApiResponse<object>> DeleteQuotationApprovalAsync(long id);
    }
}