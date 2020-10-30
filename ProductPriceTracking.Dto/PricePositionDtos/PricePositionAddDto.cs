using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.PricePositionDtos
{
    public class PricePositionAddDto : IDto
    {
        public string XPath { get; set; }
        public int Priority { get; set; }
        public int WebsiteId { get; set; }
    }
}
