using AutoMapper;

using ProductPriceTracking.Dto.AppUserDtos;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Mapping.AutoMapperProfile
{
    public class AuthorizeProfile : Profile
    {
        public AuthorizeProfile()
        {
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();

            CreateMap<AppUserLoginDto, AppUser>();
            CreateMap<AppUser, AppUserLoginDto>();

            CreateMap<AppUserAddFormDto, AppUser>();
            CreateMap<AppUser, AppUserAddFormDto>();
        }
    }
}
