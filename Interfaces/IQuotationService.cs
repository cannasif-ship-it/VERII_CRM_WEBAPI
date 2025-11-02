using cms_webapi.DTOs;
using cms_webapi.Models;

namespace cms_webapi.Interfaces
{
    public interface IQuotationService
    {
        Task<IEnumerable<QuotationGetDto>> GetAllQuotationsAsync();
        Task<QuotationGetDto?> GetQuotationByIdAsync(long id);
        Task<QuotationDto> CreateQuotationAsync(CreateQuotationDto createQuotationDto);
        Task<QuotationDto?> UpdateQuotationAsync(long id, UpdateQuotationDto updateQuotationDto);
        Task<bool> DeleteQuotationAsync(long id);
        Task<IEnumerable<QuotationGetDto>> GetQuotationsByPotentialCustomerIdAsync(long potentialCustomerId);
        Task<IEnumerable<QuotationGetDto>> GetQuotationsByRepresentativeIdAsync(long representativeId);
        Task<IEnumerable<QuotationGetDto>> GetQuotationsByStatusAsync(int status);
        Task<bool> QuotationExistsAsync(long id);
    }
}
