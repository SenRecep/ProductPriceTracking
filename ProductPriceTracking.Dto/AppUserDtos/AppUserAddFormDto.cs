using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.AppUserDtos
{
    public class AppUserAddFormDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }
    }
}
