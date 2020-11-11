using AutoMapper;
using ProductPriceTracking.Dto.TrackingRecordDtos;
using ProductPriceTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

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
