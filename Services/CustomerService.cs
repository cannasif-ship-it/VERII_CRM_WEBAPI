using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;

namespace cms_webapi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _unitOfWork.Customers.GetAllAsync();
                var customerDtos = _mapper.Map<List<CustomerGetDto>>(customers);

                return ApiResponse<List<CustomerGetDto>>.SuccessResult(customerDtos, _localizationService.GetLocalizedString("CustomersRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<CustomerGetDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<CustomerGetDto>> GetCustomerByIdAsync(long id)
        {
            try
            {
                var customer = await _unitOfWork.Customers.GetByIdAsync(id);
                if (customer == null)
                {
                    return ApiResponse<CustomerGetDto>.ErrorResult(_localizationService.GetLocalizedString("CustomerNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var customerDto = _mapper.Map<CustomerGetDto>(customer);
                return ApiResponse<CustomerGetDto>.SuccessResult(customerDto, _localizationService.GetLocalizedString("CustomerRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<CustomerGetDto>> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerCreateDto);
                var createdCustomer = await _unitOfWork.Customers.AddAsync(customer);
                await _unitOfWork.SaveChangesAsync();

                var customerDto = _mapper.Map<CustomerGetDto>(createdCustomer);

                return ApiResponse<CustomerGetDto>.SuccessResult(customerDto, _localizationService.GetLocalizedString("CustomerCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<CustomerGetDto>> UpdateCustomerAsync(long id, CustomerUpdateDto customerUpdateDto)
        {
            try
            {
                var customer = await _unitOfWork.Customers.GetByIdAsync(id);
                if (customer == null)
                {
                    return ApiResponse<CustomerGetDto>.ErrorResult(_localizationService.GetLocalizedString("CustomerNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(customerUpdateDto, customer);
                var updatedCustomer = await _unitOfWork.Customers.UpdateAsync(customer);
                await _unitOfWork.SaveChangesAsync();

                var customerDto = _mapper.Map<CustomerGetDto>(updatedCustomer);

                return ApiResponse<CustomerGetDto>.SuccessResult(customerDto, _localizationService.GetLocalizedString("CustomerUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<CustomerGetDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteCustomerAsync(long id)
        {
            try
            {
                var customer = await _unitOfWork.Customers.GetByIdAsync(id);
                if (customer == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("CustomerNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                await _unitOfWork.Customers.SoftDeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("CustomerDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
