using Microsoft.AspNetCore.Http;
using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.WebsiteDtos
{
    public class WebsiteUpdateDto : IDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string IconName { get; set; }
        public IFormFile Icon { get; set; }
    }
}
