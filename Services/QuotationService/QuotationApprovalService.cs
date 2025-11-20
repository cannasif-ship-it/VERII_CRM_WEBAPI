using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace cms_webapi.Services
{
    public class QuotationApprovalService : IQuotationApprovalService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _loc;

        public QuotationApprovalService(IUnitOfWork uow, IMapper mapper, ILocalizationService loc)
        {
            _uow = uow; _mapper = mapper; _loc = loc;
        }

        public async Task<ApiResponse<List<QuotationApprovalDto>>> GetAllQuotationApprovalsAsync()
        {
            try
            {
                var items = await _uow.QuotationApprovals.GetAllAsync();
                var dtos = _mapper.Map<List<QuotationApprovalDto>>(items.ToList());
                return ApiResponse<List<QuotationApprovalDto>>.SuccessResult(dtos, _loc.GetLocalizedString("QuotationApprovalsRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<QuotationApprovalDto>>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationApprovalDto>> GetQuotationApprovalByIdAsync(long id)
        {
            try
            {
                var item = await _uow.QuotationApprovals.GetByIdAsync(id);
                if (item == null) return ApiResponse<QuotationApprovalDto>.ErrorResult(_loc.GetLocalizedString("QuotationApprovalNotFound"), "Not found", StatusCodes.Status404NotFound);
                var dto = _mapper.Map<QuotationApprovalDto>(item);
                return ApiResponse<QuotationApprovalDto>.SuccessResult(dto, _loc.GetLocalizedString("QuotationApprovalRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationApprovalDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationApprovalDto>> CreateQuotationApprovalAsync(CreateQuotationApprovalDto dto)
        {
            try
            {
                var entity = _mapper.Map<QuotationApproval>(dto);
                entity.CreatedDate = DateTime.UtcNow;
                await _uow.QuotationApprovals.AddAsync(entity);
                await _uow.SaveChangesAsync();
                var outDto = _mapper.Map<QuotationApprovalDto>(entity);
                return ApiResponse<QuotationApprovalDto>.SuccessResult(outDto, _loc.GetLocalizedString("QuotationApprovalCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationApprovalDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationApprovalDto>> UpdateQuotationApprovalAsync(long id, UpdateQuotationApprovalDto dto)
        {
            try
            {
                var entity = await _uow.QuotationApprovals.GetByIdAsync(id);
                if (entity == null) return ApiResponse<QuotationApprovalDto>.ErrorResult(_loc.GetLocalizedString("QuotationApprovalNotFound"), "Not found", StatusCodes.Status404NotFound);
                _mapper.Map(dto, entity);
                entity.UpdatedDate = DateTime.UtcNow;
                await _uow.QuotationApprovals.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                var outDto = _mapper.Map<QuotationApprovalDto>(entity);
                return ApiResponse<QuotationApprovalDto>.SuccessResult(outDto, _loc.GetLocalizedString("QuotationApprovalUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationApprovalDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteQuotationApprovalAsync(long id)
        {
            try
            {
                var entity = await _uow.QuotationApprovals.GetByIdAsync(id);
                if (entity == null) return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("QuotationApprovalNotFound"), "Not found", StatusCodes.Status404NotFound);
                await _uow.QuotationApprovals.SoftDeleteAsync(id);
                await _uow.SaveChangesAsync();
                return ApiResponse<object>.SuccessResult(null, _loc.GetLocalizedString("QuotationApprovalDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}