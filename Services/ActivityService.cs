using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;

namespace cms_webapi.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public ActivityService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<ActivityDto>>> GetAllActivitiesAsync()
        {
            try
            {
                var activities = await _unitOfWork.Activities.GetAllAsync();
                var activityDtos = _mapper.Map<List<ActivityDto>>(activities);

                return ApiResponse<List<ActivityDto>>.SuccessResult(activityDtos, _localizationService.GetLocalizedString("ActivitiesRetrieved"));
            
            }
            catch (Exception ex)
            {
                return  ApiResponse<List<ActivityDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"),ex.Message,500);
            }
        }

        public async Task<ApiResponse<ActivityDto>> GetActivityByIdAsync(long id)
        {
            try
            {
                var activity = await _unitOfWork.Activities.GetByIdAsync(id);
                if (activity == null)
                {
                    return ApiResponse<ActivityDto>.ErrorResult(_localizationService.GetLocalizedString("ActivityNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var activityDto = _mapper.Map<ActivityDto>(activity);
                return ApiResponse<ActivityDto>.SuccessResult(activityDto, _localizationService.GetLocalizedString("ActivityRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ActivityDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ActivityDto>> CreateActivityAsync(CreateActivityDto createActivityDto)
        {
            try
            {
                var activity = _mapper.Map<Activity>(createActivityDto);
                var createdActivity = await _unitOfWork.Activities.AddAsync(activity);
                await _unitOfWork.SaveChangesAsync();

                var activityDto = _mapper.Map<ActivityDto>(createdActivity);

                return ApiResponse<ActivityDto>.SuccessResult(activityDto, _localizationService.GetLocalizedString("ActivityCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ActivityDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ActivityDto>> UpdateActivityAsync(long id, UpdateActivityDto updateActivityDto)
        {
            try
            {
                var activity = await _unitOfWork.Activities.GetByIdAsync(id);
                if (activity == null)
                {
                    return ApiResponse<ActivityDto>.ErrorResult(_localizationService.GetLocalizedString("ActivityNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(updateActivityDto, activity);
                var updatedActivity = await _unitOfWork.Activities.UpdateAsync(activity);
                await _unitOfWork.SaveChangesAsync();

                var activityDto = _mapper.Map<ActivityDto>(updatedActivity);

                return ApiResponse<ActivityDto>.SuccessResult(activityDto, _localizationService.GetLocalizedString("ActivityUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ActivityDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteActivityAsync(long id)
        {
            try
            {
                var activity = await _unitOfWork.Activities.GetByIdAsync(id);
                if (activity == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("ActivityNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                await _unitOfWork.Activities.SoftDeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(activity, _localizationService.GetLocalizedString("ActivityDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
