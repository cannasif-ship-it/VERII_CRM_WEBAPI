using cms_webapi.DTOs;

namespace cms_webapi.Interfaces
{
    public interface IQuotationDocumentTypeService
    {
        Task<ApiResponse<List<QuotationDocumentTypeDto>>> GetAllAsync();
        Task<ApiResponse<QuotationDocumentTypeDto>> GetByIdAsync(long id);
        Task<ApiResponse<QuotationDocumentTypeDto>> CreateAsync(CreateQuotationDocumentTypeDto dto);
        Task<ApiResponse<QuotationDocumentTypeDto>> UpdateAsync(long id, UpdateQuotationDocumentTypeDto dto);
        Task<ApiResponse<object>> DeleteAsync(long id);
        Task<ApiResponse<string>> GenerateQuotationNumberAsync(long customerTypeId);
    }
}