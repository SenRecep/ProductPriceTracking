using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.TrackingRecordDtos
{
    public class TrackingRecordUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
        public int WebsiteId { get; set; }
    }
}
