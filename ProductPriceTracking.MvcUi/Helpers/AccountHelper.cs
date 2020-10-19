using ProductPriceTracking.Dto.AppUserDtos;
using ProductPriceTracking.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace ProductPriceTracking.MvcUi.Helpers
{
    public class AccountHelper
    {
        public AppUserDto GenerateAppUserDto(AppUser appUser, ICollection<AppRole> appRoles)
        {
            return new AppUserDto()
            {
                Id= appUser.Id,
                FullName = appUser?.FullName,
                UserName = appUser?.UserName,
                Roles = appRoles?.Select(x => x.Name).ToList()
            };
        }
    }
}
