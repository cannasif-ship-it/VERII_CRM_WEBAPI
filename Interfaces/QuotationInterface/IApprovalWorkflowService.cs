using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    public interface IApprovalWorkflowService
    {
        Task<ApiResponse<List<ApprovalWorkflowDto>>> GetAllApprovalWorkflowsAsync();
        Task<ApiResponse<ApprovalWorkflowDto>> GetApprovalWorkflowByIdAsync(long id);
        Task<ApiResponse<ApprovalWorkflowDto>> CreateApprovalWorkflowAsync(CreateApprovalWorkflowDto dto);
        Task<ApiResponse<ApprovalWorkflowDto>> UpdateApprovalWorkflowAsync(long id, UpdateApprovalWorkflowDto dto);
        Task<ApiResponse<object>> DeleteApprovalWorkflowAsync(long id);
    }
}