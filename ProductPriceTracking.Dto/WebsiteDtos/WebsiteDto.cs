using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.WebsiteDtos
{
    public class WebsiteDto : IDto
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string IconName { get; set; }
    }
}
