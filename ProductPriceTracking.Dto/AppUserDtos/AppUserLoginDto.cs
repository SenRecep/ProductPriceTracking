using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
