using System.Collections.Generic;

using ProductPriceTracking.Core.DTO.Interfaces;

namespace ProductPriceTracking.Dto.AppUserDtos
{
    public class AppUserDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
