using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;

namespace cms_webapi.Services
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public PaymentTypeService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<PaymentTypeDto>>> GetAllPaymentTypesAsync()
        {
            try
            {
                var paymentTypes = await _unitOfWork.PaymentTypes.GetAllAsync();
                var paymentTypeDtos = _mapper.Map<List<PaymentTypeDto>>(paymentTypes);

                return ApiResponse<List<PaymentTypeDto>>.SuccessResult(paymentTypeDtos,_localizationService.GetLocalizedString("PaymentTypesRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<PaymentTypeDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<PaymentTypeDto>> GetPaymentTypeByIdAsync(long id)
        {
            try
            {
                var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
                if (paymentType == null)
                {
                    return ApiResponse<PaymentTypeDto>.ErrorResult(_localizationService.GetLocalizedString("PaymentTypeNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var paymentTypeDto = _mapper.Map<PaymentTypeDto>(paymentType);

                return ApiResponse<PaymentTypeDto>.SuccessResult(paymentTypeDto, _localizationService.GetLocalizedString("PaymentTypeRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<PaymentTypeDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<PaymentTypeDto>> CreatePaymentTypeAsync(CreatePaymentTypeDto createPaymentTypeDto)
        {
            try
            {
                var paymentType = _mapper.Map<PaymentType>(createPaymentTypeDto);
                paymentType.CreatedDate = DateTime.UtcNow;

                await _unitOfWork.PaymentTypes.AddAsync(paymentType);
                await _unitOfWork.SaveChangesAsync();

                var paymentTypeDto = _mapper.Map<PaymentTypeDto>(paymentType);

                return ApiResponse<PaymentTypeDto>.SuccessResult(paymentTypeDto, _localizationService.GetLocalizedString("PaymentTypeCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<PaymentTypeDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<PaymentTypeDto>> UpdatePaymentTypeAsync(long id, UpdatePaymentTypeDto updatePaymentTypeDto)
        {
            try
            {
                var existingPaymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
                if (existingPaymentType == null)
                {
                    return ApiResponse<PaymentTypeDto>.ErrorResult(_localizationService.GetLocalizedString("PaymentTypeNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(updatePaymentTypeDto, existingPaymentType);
                existingPaymentType.UpdatedDate = DateTime.UtcNow;

                await _unitOfWork.PaymentTypes.UpdateAsync(existingPaymentType);
                await _unitOfWork.SaveChangesAsync();

                var paymentTypeDto = _mapper.Map<PaymentTypeDto>(existingPaymentType);

                return ApiResponse<PaymentTypeDto>.SuccessResult(paymentTypeDto, _localizationService.GetLocalizedString("PaymentTypeUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<PaymentTypeDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeletePaymentTypeAsync(long id)
        {
            try
            {
                var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
                if (paymentType == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("PaymentTypeNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                await _unitOfWork.PaymentTypes.SoftDeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("PaymentTypeDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
