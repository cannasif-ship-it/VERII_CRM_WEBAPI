using AutoMapper;
using cms_webapi.Models;
using cms_webapi.DTOs;

namespace cms_webapi.Mappings
{
    public class UserDiscountLimitMappingProfile : Profile
    {
        public UserDiscountLimitMappingProfile()
        {
            // UserDiscountLimit mappings
            CreateMap<UserDiscountLimit, UserDiscountLimitDto>();

            CreateMap<CreateUserDiscountLimitDto, UserDiscountLimit>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Salespersons, opt => opt.Ignore());

            CreateMap<UpdateUserDiscountLimitDto, UserDiscountLimit>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Salespersons, opt => opt.Ignore());
        }
    }
}