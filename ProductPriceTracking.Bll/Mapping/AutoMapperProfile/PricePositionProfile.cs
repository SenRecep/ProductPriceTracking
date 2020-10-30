using AutoMapper;
using ProductPriceTracking.Dto.PricePositionDtos;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Mapping.AutoMapperProfile
{
    public class PricePositionProfile : Profile
    {
        public PricePositionProfile()
        {
            CreateMap<PricePosition, PricePositionAddDto>();
            CreateMap<PricePositionAddDto, PricePosition>();

            CreateMap<PricePosition, PricePositionUpdateDto>();
            CreateMap<PricePositionUpdateDto, PricePosition>();

        }
    }
}
