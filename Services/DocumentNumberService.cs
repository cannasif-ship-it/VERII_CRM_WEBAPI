using cms_webapi.Interfaces;
using cms_webapi.UnitOfWork;
using System.Linq;

namespace cms_webapi.Services
{
    public class DocumentNumberService : IDocumentNumberService
    {
        private readonly IUnitOfWork _uow;

        public DocumentNumberService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<string> GenerateQuotationNumberAsync(long customerTypeId)
        {
            var docType = (await _uow.QuotationDocumentTypes.FindAsync(x => x.customerTypeId == customerTypeId)).FirstOrDefault();
            var prefix = docType?.DocumentTypeName ?? "Q";
            var year = DateTime.Now.Year.ToString();
            var existing = await _uow.Quotations.FindAsync(q => q.Year == year && q.OfferNo != null && q.OfferNo.StartsWith(prefix + "-" + year));
            var seq = existing.Count() + 1;
            return $"{prefix}-{year}-{seq:D8}";
        }
    }
}