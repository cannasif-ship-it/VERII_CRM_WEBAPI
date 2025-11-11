using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace cms_webapi.Services
{
    public class QuotationLineService : IQuotationLineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public QuotationLineService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<QuotationLineGetDto>>> GetAllQuotationLinesAsync()
        {
            try
            {
                var lines = await _unitOfWork.QuotationLines.GetAllAsync();
                var dtos = _mapper.Map<List<QuotationLineGetDto>>(lines.ToList());
                return ApiResponse<List<QuotationLineGetDto>>.SuccessResult(dtos, _localizationService.GetLocalizedString("QuotationLinesRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<QuotationLineGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationLineGetDto>> GetQuotationLineByIdAsync(long id)
        {
            try
            {
                var line = await _unitOfWork.QuotationLines.GetByIdAsync(id);
                if (line == null)
                {
                    return ApiResponse<QuotationLineGetDto>.ErrorResult(_localizationService.GetLocalizedString("QuotationLineNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var dto = _mapper.Map<QuotationLineGetDto>(line);
                return ApiResponse<QuotationLineGetDto>.SuccessResult(dto, _localizationService.GetLocalizedString("QuotationLineRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationLineGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationLineDto>> CreateQuotationLineAsync(CreateQuotationLineDto createQuotationLineDto)
        {
            try
            {
                var entity = _mapper.Map<QuotationLine>(createQuotationLineDto);
                entity.CreatedDate = DateTime.UtcNow;

                await _unitOfWork.QuotationLines.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                var dto = _mapper.Map<QuotationLineDto>(entity);
                return ApiResponse<QuotationLineDto>.SuccessResult(dto, _localizationService.GetLocalizedString("QuotationLineCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationLineDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationLineDto>> UpdateQuotationLineAsync(long id, UpdateQuotationLineDto updateQuotationLineDto)
        {
            try
            {
                var existing = await _unitOfWork.QuotationLines.GetByIdAsync(id);
                if (existing == null)
                {
                    return ApiResponse<QuotationLineDto>.ErrorResult(_localizationService.GetLocalizedString("QuotationLineNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(updateQuotationLineDto, existing);
                existing.UpdatedDate = DateTime.UtcNow;

                await _unitOfWork.QuotationLines.UpdateAsync(existing);
                await _unitOfWork.SaveChangesAsync();

                var dto = _mapper.Map<QuotationLineDto>(existing);
                return ApiResponse<QuotationLineDto>.SuccessResult(dto, _localizationService.GetLocalizedString("QuotationLineUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationLineDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteQuotationLineAsync(long id)
        {
            try
            {
                var existing = await _unitOfWork.QuotationLines.GetByIdAsync(id);
                if (existing == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("QuotationLineNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                await _unitOfWork.QuotationLines.SoftDeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("QuotationLineDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<List<QuotationLineGetDto>>> GetQuotationLinesByQuotationIdAsync(long quotationId)
        {
            try
            {
                var lines = await _unitOfWork.QuotationLines.FindAsync(q => q.QuotationId == quotationId);
                var dtos = _mapper.Map<List<QuotationLineGetDto>>(lines.ToList());
                return ApiResponse<List<QuotationLineGetDto>>.SuccessResult(dtos, _localizationService.GetLocalizedString("QuotationLinesByQuotationRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<QuotationLineGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}