using System.Threading.Tasks;

namespace cms_webapi.Interfaces
{
    public interface IDocumentNumberService
    {
        Task<string> GenerateQuotationNumberAsync(long customerTypeId);
    }
}