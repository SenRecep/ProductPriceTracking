using ProductPriceTracking.Dto.AppUserDtos;
using ProductPriceTracking.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface IAppUserService
    {
        Task<AppUser> FindByUserName(string userName);
        bool CheckPassword(AppUserLoginDto appUserLoginDto, AppUser appUser);
        Task<ICollection<AppRole>> GetRolesByUserName(string userName);
    }
}
