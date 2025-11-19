using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace cms_webapi.Services
{
    public class QuotationLineApprovalService : IQuotationLineApprovalService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _loc;

        public QuotationLineApprovalService(IUnitOfWork uow, IMapper mapper, ILocalizationService loc)
        {
            _uow = uow; _mapper = mapper; _loc = loc;
        }

        public async Task<ApiResponse<List<QuotationLineApprovalDto>>> GetAllQuotationLineApprovalsAsync()
        {
            try
            {
                var items = await _uow.QuotationLineApprovals.GetAllAsync();
                var dtos = _mapper.Map<List<QuotationLineApprovalDto>>(items.ToList());
                return ApiResponse<List<QuotationLineApprovalDto>>.SuccessResult(dtos, _loc.GetLocalizedString("QuotationLineApprovalsRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<QuotationLineApprovalDto>>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationLineApprovalDto>> GetQuotationLineApprovalByIdAsync(long id)
        {
            try
            {
                var item = await _uow.QuotationLineApprovals.GetByIdAsync(id);
                if (item == null) return ApiResponse<QuotationLineApprovalDto>.ErrorResult(_loc.GetLocalizedString("QuotationLineApprovalNotFound"), "Not found", StatusCodes.Status404NotFound);
                var dto = _mapper.Map<QuotationLineApprovalDto>(item);
                return ApiResponse<QuotationLineApprovalDto>.SuccessResult(dto, _loc.GetLocalizedString("QuotationLineApprovalRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationLineApprovalDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationLineApprovalDto>> CreateQuotationLineApprovalAsync(CreateQuotationLineApprovalDto dto)
        {
            try
            {
                var entity = _mapper.Map<QuotationLineApproval>(dto);
                entity.CreatedDate = DateTime.UtcNow;
                await _uow.QuotationLineApprovals.AddAsync(entity);
                await _uow.SaveChangesAsync();
                var outDto = _mapper.Map<QuotationLineApprovalDto>(entity);
                return ApiResponse<QuotationLineApprovalDto>.SuccessResult(outDto, _loc.GetLocalizedString("QuotationLineApprovalCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationLineApprovalDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationLineApprovalDto>> UpdateQuotationLineApprovalAsync(long id, UpdateQuotationLineApprovalDto dto)
        {
            try
            {
                var entity = await _uow.QuotationLineApprovals.GetByIdAsync(id);
                if (entity == null) return ApiResponse<QuotationLineApprovalDto>.ErrorResult(_loc.GetLocalizedString("QuotationLineApprovalNotFound"), "Not found", StatusCodes.Status404NotFound);
                _mapper.Map(dto, entity);
                entity.UpdatedDate = DateTime.UtcNow;
                await _uow.QuotationLineApprovals.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                var outDto = _mapper.Map<QuotationLineApprovalDto>(entity);
                return ApiResponse<QuotationLineApprovalDto>.SuccessResult(outDto, _loc.GetLocalizedString("QuotationLineApprovalUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationLineApprovalDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteQuotationLineApprovalAsync(long id)
        {
            try
            {
                var entity = await _uow.QuotationLineApprovals.GetByIdAsync(id);
                if (entity == null) return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("QuotationLineApprovalNotFound"), "Not found", StatusCodes.Status404NotFound);
                await _uow.QuotationLineApprovals.SoftDeleteAsync(id);
                await _uow.SaveChangesAsync();
                return ApiResponse<object>.SuccessResult(null, _loc.GetLocalizedString("QuotationLineApprovalDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}