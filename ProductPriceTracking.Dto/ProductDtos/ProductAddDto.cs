using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.ProductDtos
{
    public class ProductAddDto : IDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int WebsiteId { get; set; }
    }
}
