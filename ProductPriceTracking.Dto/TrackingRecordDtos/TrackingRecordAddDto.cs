using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.TrackingRecordDtos
{
    public class TrackingRecordAddDto : IDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
        public int WebsiteId { get; set; }
    }
}
