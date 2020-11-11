using ProductPriceTracking.Core.DTO.Interfaces;
using ProductPriceTracking.Entities.Concrete;
using System.Collections.Generic;

namespace ProductPriceTracking.Dto.ProductDtos
{
    public class ProductDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Website Website { get; set; }
        public IEnumerable<TrackingRecord> TrackingRecords { get; set; }
    }
}
