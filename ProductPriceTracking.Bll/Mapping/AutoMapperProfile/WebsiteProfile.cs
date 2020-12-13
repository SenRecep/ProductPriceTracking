using AutoMapper;

using ProductPriceTracking.Dto.WebsiteDtos;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Mapping.AutoMapperProfile
{
    public class WebsiteProfile : Profile
    {
        public WebsiteProfile()
        {
            CreateMap<WebsiteAddDto, Website>();
            CreateMap<Website, WebsiteAddDto>();

            CreateMap<WebsiteUpdateDto, Website>();
            CreateMap<Website, WebsiteUpdateDto>();
        }
    }
}
