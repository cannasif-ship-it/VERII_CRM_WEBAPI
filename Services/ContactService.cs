using AutoMapper;
using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using cms_webapi.Models;

namespace cms_webapi.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper, ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<ApiResponse<List<ContactDto>>> GetAllContactsAsync()
        {
            try
            {
                var contacts = await _unitOfWork.Contacts.GetAllAsync();
                var contactDtos = _mapper.Map<List<ContactDto>>(contacts);

                return ApiResponse<List<ContactDto>>.SuccessResult(contactDtos, _localizationService.GetLocalizedString("ContactsRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<List<ContactDto>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ContactDto>> GetContactByIdAsync(long id)
        {
            try
            {
                var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
                if (contact == null)
                {
                    return ApiResponse<ContactDto>.ErrorResult(_localizationService.GetLocalizedString("ContactNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                var contactDto = _mapper.Map<ContactDto>(contact);
                return ApiResponse<ContactDto>.SuccessResult(contactDto, _localizationService.GetLocalizedString("ContactRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ContactDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ContactDto>> CreateContactAsync(CreateContactDto createContactDto)
        {
            try
            {
                var contact = _mapper.Map<Contact>(createContactDto);
                var createdContact = await _unitOfWork.Contacts.AddAsync(contact);
                await _unitOfWork.SaveChangesAsync();

                var contactDto = _mapper.Map<ContactDto>(createdContact);

                return ApiResponse<ContactDto>.SuccessResult(contactDto, _localizationService.GetLocalizedString("ContactCreated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ContactDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<ContactDto>> UpdateContactAsync(long id, UpdateContactDto updateContactDto)
        {
            try
            {
                var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
                if (contact == null)
                {
                    return ApiResponse<ContactDto>.ErrorResult(_localizationService.GetLocalizedString("ContactNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                _mapper.Map(updateContactDto, contact);
                var updatedContact = await _unitOfWork.Contacts.UpdateAsync(contact);
                await _unitOfWork.SaveChangesAsync();

                var contactDto = _mapper.Map<ContactDto>(updatedContact);

                return ApiResponse<ContactDto>.SuccessResult(contactDto, _localizationService.GetLocalizedString("ContactUpdated"));
            }
            catch (Exception ex)
            {
                return ApiResponse<ContactDto>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<object>> DeleteContactAsync(long id)
        {
            try
            {
                var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
                if (contact == null)
                {
                    return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("ContactNotFound"), "Not found", StatusCodes.Status404NotFound);
                }

                await _unitOfWork.Contacts.SoftDeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<object>.SuccessResult(null, _localizationService.GetLocalizedString("ContactDeleted"));
            }
            catch (Exception ex)
            {
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
