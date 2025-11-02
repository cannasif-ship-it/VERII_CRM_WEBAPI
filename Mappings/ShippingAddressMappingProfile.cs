using AutoMapper;
using cms_webapi.Models;
using cms_webapi.DTOs;

namespace cms_webapi.Mappings
{
    public class ShippingAddressMappingProfile : Profile
    {
        public ShippingAddressMappingProfile()
        {
            // ShippingAddress mappings
            CreateMap<ShippingAddress, ShippingAddressDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.CustomerName))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Countries.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Cities.Name))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.Districts.Name));

            CreateMap<ShippingAddress, ShippingAddressGetDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.CustomerName))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Countries.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Cities.Name))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.Districts.Name))
                .ForMember(dest => dest.CreatedByFullUser, opt => opt.MapFrom(src => src.CreatedByUser != null ? $"{src.CreatedByUser.FirstName} {src.CreatedByUser.LastName}".Trim() : null))
                .ForMember(dest => dest.UpdatedByFullUser, opt => opt.MapFrom(src => src.UpdatedByUser != null ? $"{src.UpdatedByUser.FirstName} {src.UpdatedByUser.LastName}".Trim() : null))
                .ForMember(dest => dest.DeletedByFullUser, opt => opt.MapFrom(src => src.DeletedByUser != null ? $"{src.DeletedByUser.FirstName} {src.DeletedByUser.LastName}".Trim() : null));

            CreateMap<CreateShippingAddressDto, ShippingAddress>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.Countries, opt => opt.Ignore())
                .ForMember(dest => dest.Cities, opt => opt.Ignore())
                .ForMember(dest => dest.Districts, opt => opt.Ignore());

            CreateMap<UpdateShippingAddressDto, ShippingAddress>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.Countries, opt => opt.Ignore())
                .ForMember(dest => dest.Cities, opt => opt.Ignore())
                .ForMember(dest => dest.Districts, opt => opt.Ignore());
        }
    }
}