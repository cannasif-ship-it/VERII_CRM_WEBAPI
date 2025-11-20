using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;

namespace cms_webapi.Services
{
    public class TitleService : ITitleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public TitleService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<TitleDto>>> GetAllTitlesAsync()
        {
            try
            {
                var titles = await _unitOfWork.Titles.GetAllAsync();
                var titleDtos = _mapper.Map<List<TitleDto>>(titles);

                return  ApiResponse<List<TitleDto>>.SuccessResult(titleDtos, _localizationService.GetLocalizedString("TitlesRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<TitleDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<TitleDto>> GetTitleByIdAsync(long id)
        {
            try
            {
                var title = await _unitOfWork.Titles.GetByIdAsync(id);
                if (title == null)
                {
                    return ApiResponse<TitleDto>.ErrorResult(_localizationService.GetLocalizedString("TitleNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var titleDto = _mapper.Map<TitleDto>(title);
                return ApiResponse<TitleDto>.SuccessResult(titleDto, _localizationService.GetLocalizedString("TitleRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<TitleDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<TitleDto>> CreateTitleAsync(CreateTitleDto  titleCreateDto)
        {
            try
            {
                var title = _mapper.Map<Title>(titleCreateDto);
                var createdTitle = await _unitOfWork.Titles.AddAsync(title);
                await _unitOfWork.SaveChangesAsync();

                var titleDto = _mapper.Map<TitleDto>(createdTitle);

                return ApiResponse<TitleDto>.SuccessResult(titleDto, _localizationService.GetLocalizedString("TitleCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<TitleDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<TitleDto>> UpdateTitleAsync(long id, UpdateTitleDto  titleUpdateDto)
        {
            try
            {
                var title = await _unitOfWork.Titles.GetByIdAsync(id);
                if (title == null)
                {
                    return ApiResponse<TitleDto>.ErrorResult(_localizationService.GetLocalizedString("TitleNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(titleUpdateDto, title);
                var updatedTitle = await _unitOfWork.Titles.UpdateAsync(title);
                await _unitOfWork.SaveChangesAsync();

                var titleDto = _mapper.Map<TitleDto>(updatedTitle);

                return ApiResponse<TitleDto>.SuccessResult(titleDto, _localizationService.GetLocalizedString("TitleUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<TitleDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteTitleAsync(long id)
        {
            try
            {
                var title = await _unitOfWork.Titles.GetByIdAsync(id);
                if (title == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("TitleNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                await _unitOfWork.Titles.SoftDeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("TitleDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
