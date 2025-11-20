using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace cms_webapi.Services
{
    public class QuotationDocumentTypeService : IQuotationDocumentTypeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _loc;

        public QuotationDocumentTypeService(IUnitOfWork uow, IMapper mapper, ILocalizationService loc)
        {
            _uow = uow; _mapper = mapper; _loc = loc;
        }

        public async Task<ApiResponse<List<QuotationDocumentTypeDto>>> GetAllAsync()
        {
            try
            {
                var items = await _uow.QuotationDocumentTypes.GetAllAsync();
                var dtos = _mapper.Map<List<QuotationDocumentTypeDto>>(items.ToList());
                return ApiResponse<List<QuotationDocumentTypeDto>>.SuccessResult(dtos, _loc.GetLocalizedString("QuotationDocumentTypesRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<QuotationDocumentTypeDto>>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationDocumentTypeDto>> GetByIdAsync(long id)
        {
            try
            {
                var item = await _uow.QuotationDocumentTypes.GetByIdAsync(id);
                if (item == null) return ApiResponse<QuotationDocumentTypeDto>.ErrorResult(_loc.GetLocalizedString("QuotationDocumentTypeNotFound"), "Not found", StatusCodes.Status404NotFound);
                var dto = _mapper.Map<QuotationDocumentTypeDto>(item);
                return ApiResponse<QuotationDocumentTypeDto>.SuccessResult(dto, _loc.GetLocalizedString("QuotationDocumentTypeRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationDocumentTypeDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationDocumentTypeDto>> CreateAsync(CreateQuotationDocumentTypeDto dto)
        {
            try
            {
                var entity = _mapper.Map<QuotationDocumentType>(dto);
                entity.CreatedDate = DateTime.UtcNow;
                await _uow.QuotationDocumentTypes.AddAsync(entity);
                await _uow.SaveChangesAsync();
                var outDto = _mapper.Map<QuotationDocumentTypeDto>(entity);
                return ApiResponse<QuotationDocumentTypeDto>.SuccessResult(outDto, _loc.GetLocalizedString("QuotationDocumentTypeCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationDocumentTypeDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<QuotationDocumentTypeDto>> UpdateAsync(long id, UpdateQuotationDocumentTypeDto dto)
        {
            try
            {
                var entity = await _uow.QuotationDocumentTypes.GetByIdAsync(id);
                if (entity == null) return ApiResponse<QuotationDocumentTypeDto>.ErrorResult(_loc.GetLocalizedString("QuotationDocumentTypeNotFound"), "Not found", StatusCodes.Status404NotFound);
                _mapper.Map(dto, entity);
                entity.UpdatedDate = DateTime.UtcNow;
                await _uow.QuotationDocumentTypes.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                var outDto = _mapper.Map<QuotationDocumentTypeDto>(entity);
                return ApiResponse<QuotationDocumentTypeDto>.SuccessResult(outDto, _loc.GetLocalizedString("QuotationDocumentTypeUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<QuotationDocumentTypeDto>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteAsync(long id)
        {
            try
            {
                var entity = await _uow.QuotationDocumentTypes.GetByIdAsync(id);
                if (entity == null) return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("QuotationDocumentTypeNotFound"), "Not found", StatusCodes.Status404NotFound);
                await _uow.QuotationDocumentTypes.SoftDeleteAsync(id);
                await _uow.SaveChangesAsync();
                return ApiResponse<object>.SuccessResult(null, _loc.GetLocalizedString("QuotationDocumentTypeDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_loc.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}