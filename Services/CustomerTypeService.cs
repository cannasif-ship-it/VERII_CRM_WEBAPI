using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using cms_webapi.UnitOfWork;

namespace cms_webapi.Services
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public CustomerTypeService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<CustomerTypeGetDto>>> GetAllCustomerTypesAsync()
        {
            try
            {
                var customerTypes = await _unitOfWork.CustomerTypes.GetAllAsync();
                var customerTypeDtos = _mapper.Map<List<CustomerTypeGetDto>>(customerTypes);

                return ApiResponse<List<CustomerTypeGetDto>>.SuccessResult(customerTypeDtos, _localizationService.GetLocalizedString("CustomerTypesRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<CustomerTypeGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<CustomerTypeGetDto>> GetCustomerTypeByIdAsync(long id)
        {
            try
            {
                var customerType = await _unitOfWork.CustomerTypes.GetByIdAsync(id);
                if (customerType == null)
                {
                    return ApiResponse<CustomerTypeGetDto>.ErrorResult(_localizationService.GetLocalizedString("CustomerTypeNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var customerTypeDto = _mapper.Map<CustomerTypeGetDto>(customerType);
                return ApiResponse<CustomerTypeGetDto>.SuccessResult(customerTypeDto, _localizationService.GetLocalizedString("CustomerTypeRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerTypeGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<CustomerTypeGetDto>> CreateCustomerTypeAsync(CustomerTypeCreateDto customerTypeCreateDto)
        {
            try
            {
                var customerType = _mapper.Map<CustomerType>(customerTypeCreateDto);
                var createdCustomerType = await _unitOfWork.CustomerTypes.AddAsync(customerType);
                await _unitOfWork.SaveChangesAsync();
                var customerTypeDto = _mapper.Map<CustomerTypeGetDto>(createdCustomerType);

                return ApiResponse<CustomerTypeGetDto>.SuccessResult(customerTypeDto, _localizationService.GetLocalizedString("CustomerTypeCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerTypeGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<CustomerTypeGetDto>> UpdateCustomerTypeAsync(long id, CustomerTypeUpdateDto customerTypeUpdateDto)
        {
            try
            {
                var customerType = await _unitOfWork.CustomerTypes.GetByIdAsync(id);
                if (customerType == null)
                {
                    return ApiResponse<CustomerTypeGetDto>.ErrorResult(_localizationService.GetLocalizedString("CustomerTypeNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(customerTypeUpdateDto, customerType);
                var updatedCustomerType = await _unitOfWork.CustomerTypes.UpdateAsync(customerType);
                await _unitOfWork.SaveChangesAsync();
                var customerTypeDto = _mapper.Map<CustomerTypeGetDto>(updatedCustomerType);

                return ApiResponse<CustomerTypeGetDto>.SuccessResult(customerTypeDto, _localizationService.GetLocalizedString("CustomerTypeUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerTypeGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteCustomerTypeAsync(long id)
        {
            try
            {
                var customerType = await _unitOfWork.CustomerTypes.GetByIdAsync(id);
                if (customerType == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("CustomerTypeNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                await _unitOfWork.CustomerTypes.SoftDeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("CustomerTypeDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
