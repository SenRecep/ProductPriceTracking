using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.ProductDtos
{
    public class ProductUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int WebsiteId { get; set; }
    }
}
