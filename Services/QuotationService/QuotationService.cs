using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Models;
using cms_webapi.Interfaces;
using cms_webapi.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace cms_webapi.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        private readonly IQuotationDocumentTypeService _quotationDocumentTypeService;

        public QuotationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILocalizationService localizationService,
            IQuotationDocumentTypeService quotationDocumentTypeService) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
            _quotationDocumentTypeService = quotationDocumentTypeService;
        }

        public async Task<ApiResponse<List<QuotationGetDto>>> GetAllQuotationsAsync()
        {
            try
            {
                var quotations = await _unitOfWork.Quotations.GetAllAsync();
                var quotationDtos = _mapper.Map<List<QuotationGetDto>>(quotations.ToList());
                return ApiResponse<List<QuotationGetDto>>.SuccessResult(quotationDtos, _localizationService.GetLocalizedString("QuotationsRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<QuotationGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationGetDto>> GetQuotationByIdAsync(long id)
        {
            try
            {
                var quotation = await _unitOfWork.Quotations.GetByIdAsync(id);
                if (quotation == null)
                {
                    return ApiResponse<QuotationGetDto>.ErrorResult(_localizationService.GetLocalizedString("QuotationNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var quotationDto = _mapper.Map<QuotationGetDto>(quotation);
                return ApiResponse<QuotationGetDto>.SuccessResult(quotationDto, _localizationService.GetLocalizedString("QuotationRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationDto>> CreateQuotationAsync(CreateQuotationDto createQuotationDto)
        {
            try
            {
                var quotation = _mapper.Map<Quotation>(createQuotationDto);
                quotation.CreatedDate = DateTime.UtcNow;

                await _unitOfWork.Quotations.AddAsync(quotation);
                await _unitOfWork.SaveChangesAsync();

                var quotationDto = _mapper.Map<QuotationDto>(quotation);
                return ApiResponse<QuotationDto>.SuccessResult(quotationDto, _localizationService.GetLocalizedString("QuotationCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationDto>> UpdateQuotationAsync(long id, UpdateQuotationDto updateQuotationDto)
        {
            try
            {
                var quotation = await _unitOfWork.Quotations.GetByIdAsync(id);
                if (quotation == null)
                {
                    return ApiResponse<QuotationDto>.ErrorResult(_localizationService.GetLocalizedString("QuotationNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(updateQuotationDto, quotation);
                quotation.UpdatedDate = DateTime.UtcNow;

                await _unitOfWork.Quotations.UpdateAsync(quotation);
                await _unitOfWork.SaveChangesAsync();

                var quotationDto = _mapper.Map<QuotationDto>(quotation);
                return ApiResponse<QuotationDto>.SuccessResult(quotationDto, _localizationService.GetLocalizedString("QuotationUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteQuotationAsync(long id)
        {
            try
            {
                var quotation = await _unitOfWork.Quotations.GetByIdAsync(id);
                if (quotation == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("QuotationNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                await _unitOfWork.Quotations.SoftDeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("QuotationDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<List<QuotationGetDto>>> GetQuotationsByPotentialCustomerIdAsync(long potentialCustomerId)
        {
            try
            {
                var quotations = await _unitOfWork.Quotations.FindAsync(q => q.PotentialCustomerId == potentialCustomerId);
                var quotationDtos = _mapper.Map<List<QuotationGetDto>>(quotations.ToList());
                return ApiResponse<List<QuotationGetDto>>.SuccessResult(quotationDtos, _localizationService.GetLocalizedString("QuotationsByPotentialCustomerRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<QuotationGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<List<QuotationGetDto>>> GetQuotationsByRepresentativeIdAsync(long representativeId)
        {
            try
            {
                var quotations = await _unitOfWork.Quotations.FindAsync(q => q.RepresentativeId == representativeId);
                var quotationDtos = _mapper.Map<List<QuotationGetDto>>(quotations.ToList());
                return ApiResponse<List<QuotationGetDto>>.SuccessResult(quotationDtos, _localizationService.GetLocalizedString("QuotationsByRepresentativeRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<QuotationGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<List<QuotationGetDto>>> GetQuotationsByStatusAsync(int status)
        {
            try
            {
                var quotations = await _unitOfWork.Quotations.FindAsync(q => q.Status == status);
                var quotationDtos = _mapper.Map<List<QuotationGetDto>>(quotations.ToList());
                return ApiResponse<List<QuotationGetDto>>.SuccessResult(quotationDtos, _localizationService.GetLocalizedString("QuotationsByStatusRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<QuotationGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<bool>> QuotationExistsAsync(long id)
        {
            try
            {
                var exists = await _unitOfWork.Quotations.ExistsAsync(id);
                return ApiResponse<bool>.SuccessResult(exists, exists ? _localizationService.GetLocalizedString("QuotationRetrieved") : _localizationService.GetLocalizedString("QuotationNotFound"));
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<CreateBulkQuotationResultDto>> CreateBulkQuotationAsync(CreateBulkQuotationDto dto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var offerNo = string.Empty;
                var offerNoResponse = await _quotationDocumentTypeService.GenerateQuotationNumberAsync(dto.customerTypeId);
                if (offerNoResponse.Success)
                {
                    offerNo = offerNoResponse.Data;
                }
                else
                {
                    return ApiResponse<CreateBulkQuotationResultDto>.ErrorResult(offerNoResponse.Message, offerNoResponse.ExceptionMessage, offerNoResponse.StatusCode);
                }

                var quotation = _mapper.Map<Quotation>(dto.Header);
                quotation.OfferNo = offerNo;

                await _unitOfWork.Quotations.AddAsync(quotation);
                await _unitOfWork.SaveChangesAsync();

                var createdLines = new List<QuotationLine>();
                foreach (var line in dto.Lines)
                {
                    var entity = new QuotationLine
                    {
                        QuotationId = quotation.Id,
                        ProductCode = line.ProductCode,
                        Quantity = line.Quantity,
                        UnitPrice = line.UnitPrice,
                        DiscountRate1 = line.DiscountRate1,
                        DiscountAmount1 = line.DiscountAmount1,
                        DiscountRate2 = line.DiscountRate2,
                        DiscountAmount2 = line.DiscountAmount2,
                        DiscountRate3 = line.DiscountRate3,
                        DiscountAmount3 = line.DiscountAmount3,
                        VatRate = line.VatRate,
                        VatAmount = line.VatAmount,
                        LineTotal = line.LineTotal,
                        LineGrandTotal = line.LineGrandTotal,
                        Description = line.Description,
                        CreatedDate = DateTime.UtcNow
                    };

                    await _unitOfWork.QuotationLines.AddAsync(entity);
                    createdLines.Add(entity);
                }

                quotation.Total = createdLines.Sum(x => x.LineTotal);
                quotation.GrandTotal = createdLines.Sum(x => x.LineGrandTotal);
                await _unitOfWork.Quotations.UpdateAsync(quotation);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var result = new CreateBulkQuotationResultDto
                {
                    Quotation = _mapper.Map<QuotationDto>(quotation),
                    Lines = _mapper.Map<List<QuotationLineDto>>(createdLines)
                };

                return ApiResponse<CreateBulkQuotationResultDto>.SuccessResult(result, _localizationService.GetLocalizedString("QuotationCreated"));
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResponse<CreateBulkQuotationResultDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
