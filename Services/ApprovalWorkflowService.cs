using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace cms_webapi.Services
{
    public class ApprovalWorkflowService : IApprovalWorkflowService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _loc;

        public ApprovalWorkflowService(IUnitOfWork uow, IMapper mapper, ILocalizationService loc)
        {
            _uow = uow; _mapper = mapper; _loc = loc;
        }

        public async Task<ApiResponse<List<ApprovalWorkflowDto>>> GetAllApprovalWorkflowsAsync()
        {
            try
            {
                var items = await _uow.ApprovalWorkflows.GetAllAsync();
                var dtos = _mapper.Map<List<ApprovalWorkflowDto>>(items.ToList());
                return ApiResponse<List<ApprovalWorkflowDto>>.SuccessResult(dtos, _loc.GetLocalizedString("ApprovalWorkflowsRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<ApprovalWorkflowDto>>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ApprovalWorkflowDto>> GetApprovalWorkflowByIdAsync(long id)
        {
            try
            {
                var item = await _uow.ApprovalWorkflows.GetByIdAsync(id);
                if (item == null) return ApiResponse<ApprovalWorkflowDto>.ErrorResult(_loc.GetLocalizedString("ApprovalWorkflowNotFound"), "Not found", StatusCodes.Status404NotFound);
                var dto = _mapper.Map<ApprovalWorkflowDto>(item);
                return ApiResponse<ApprovalWorkflowDto>.SuccessResult(dto, _loc.GetLocalizedString("ApprovalWorkflowRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ApprovalWorkflowDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ApprovalWorkflowDto>> CreateApprovalWorkflowAsync(CreateApprovalWorkflowDto dto)
        {
            try
            {
                var entity = _mapper.Map<ApprovalWorkflow>(dto);
                entity.CreatedDate = DateTime.UtcNow;
                await _uow.ApprovalWorkflows.AddAsync(entity);
                await _uow.SaveChangesAsync();
                var outDto = _mapper.Map<ApprovalWorkflowDto>(entity);
                return ApiResponse<ApprovalWorkflowDto>.SuccessResult(outDto, _loc.GetLocalizedString("ApprovalWorkflowCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ApprovalWorkflowDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ApprovalWorkflowDto>> UpdateApprovalWorkflowAsync(long id, UpdateApprovalWorkflowDto dto)
        {
            try
            {
                var entity = await _uow.ApprovalWorkflows.GetByIdAsync(id);
                if (entity == null) return ApiResponse<ApprovalWorkflowDto>.ErrorResult(_loc.GetLocalizedString("ApprovalWorkflowNotFound"), "Not found", StatusCodes.Status404NotFound);
                _mapper.Map(dto, entity);
                entity.UpdatedDate = DateTime.UtcNow;
                await _uow.ApprovalWorkflows.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                var outDto = _mapper.Map<ApprovalWorkflowDto>(entity);
                return ApiResponse<ApprovalWorkflowDto>.SuccessResult(outDto, _loc.GetLocalizedString("ApprovalWorkflowUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ApprovalWorkflowDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteApprovalWorkflowAsync(long id)
        {
            try
            {
                var entity = await _uow.ApprovalWorkflows.GetByIdAsync(id);
                if (entity == null) return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("ApprovalWorkflowNotFound"), "Not found", StatusCodes.Status404NotFound);
                await _uow.ApprovalWorkflows.SoftDeleteAsync(id);
                await _uow.SaveChangesAsync();
                return ApiResponse<object>.SuccessResult(null, _loc.GetLocalizedString("ApprovalWorkflowDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}