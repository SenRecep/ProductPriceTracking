using AutoMapper;

using ProductPriceTracking.Dto.TrackingRecordDtos;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Mapping.AutoMapperProfile
{
    public class TrackingRecordProfile : Profile
    {
        public TrackingRecordProfile()
        {
            CreateMap<TrackingRecord, TrackingRecordAddDto>();
            CreateMap<TrackingRecordAddDto, TrackingRecord>();

            CreateMap<TrackingRecord, TrackingRecordUpdateDto>();
            CreateMap<TrackingRecordUpdateDto, TrackingRecord>();

        
        }
    }
}
