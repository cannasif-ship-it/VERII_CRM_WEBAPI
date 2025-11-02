using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Models;
using cms_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cms_webapi.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public QuotationService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<IEnumerable<QuotationGetDto>> GetAllQuotationsAsync()
        {
            var quotations = await _unitOfWork.Quotations.GetAllAsync();

            return _mapper.Map<IEnumerable<QuotationGetDto>>(quotations);
        }

        public async Task<QuotationGetDto?> GetQuotationByIdAsync(long id)
        {
            var quotation = await _unitOfWork.Quotations.GetByIdAsync(id);

            return quotation != null ? _mapper.Map<QuotationGetDto>(quotation) : null;
        }

        public async Task<QuotationDto> CreateQuotationAsync(CreateQuotationDto createQuotationDto)
        {
            var quotation = _mapper.Map<Quotation>(createQuotationDto);
            quotation.CreatedDate = DateTime.UtcNow;

            await _unitOfWork.Quotations.AddAsync(quotation);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<QuotationDto>(quotation);
        }

        public async Task<QuotationDto?> UpdateQuotationAsync(long id, UpdateQuotationDto updateQuotationDto)
        {
            var quotation = await _unitOfWork.Quotations.GetByIdAsync(id);
            if (quotation == null)
                return null;

            _mapper.Map(updateQuotationDto, quotation);
            quotation.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.Quotations.UpdateAsync(quotation);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<QuotationDto>(quotation);
        }

        public async Task<bool> DeleteQuotationAsync(long id)
        {
            var quotation = await _unitOfWork.Quotations.GetByIdAsync(id);
            if (quotation == null)
                return false;

             await _unitOfWork.Quotations.SoftDeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<QuotationGetDto>> GetQuotationsByPotentialCustomerIdAsync(long potentialCustomerId)
        {
            var quotations = await _unitOfWork.Quotations
                .GetAllAsync();

            return _mapper.Map<IEnumerable<QuotationGetDto>>(quotations);
        }

        public async Task<IEnumerable<QuotationGetDto>> GetQuotationsByRepresentativeIdAsync(long representativeId)
        {
            var quotations = await _unitOfWork.Quotations
                .GetAllAsync();

            return _mapper.Map<IEnumerable<QuotationGetDto>>(quotations);
        }

        public async Task<IEnumerable<QuotationGetDto>> GetQuotationsByStatusAsync(int status)
        {
            var quotations = await _unitOfWork.Quotations
                .GetAllAsync();

            return _mapper.Map<IEnumerable<QuotationGetDto>>(quotations);
        }

        public async Task<bool> QuotationExistsAsync(long id)
        {
            return await _unitOfWork.Quotations.ExistsAsync(id);
        }
    }
}
