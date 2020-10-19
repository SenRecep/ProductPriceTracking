using Microsoft.AspNetCore.Http;
using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.WebsiteDtos
{
    public class WebsiteAddDto : IDto
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public IFormFile Icon { get; set; }
    }
}
