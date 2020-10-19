using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.TrackingRecordDtos
{
    public class TrackingRecordDto : IDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
    }
}
