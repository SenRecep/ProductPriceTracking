using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.AppUserDtos
{
    public class AppUserAddDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
