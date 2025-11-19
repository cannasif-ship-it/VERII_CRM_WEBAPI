using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    public interface IQuotationLineApprovalService
    {
        Task<ApiResponse<List<QuotationLineApprovalDto>>> GetAllQuotationLineApprovalsAsync();
        Task<ApiResponse<QuotationLineApprovalDto>> GetQuotationLineApprovalByIdAsync(long id);
        Task<ApiResponse<QuotationLineApprovalDto>> CreateQuotationLineApprovalAsync(CreateQuotationLineApprovalDto dto);
        Task<ApiResponse<QuotationLineApprovalDto>> UpdateQuotationLineApprovalAsync(long id, UpdateQuotationLineApprovalDto dto);
        Task<ApiResponse<object>> DeleteQuotationLineApprovalAsync(long id);
    }
}