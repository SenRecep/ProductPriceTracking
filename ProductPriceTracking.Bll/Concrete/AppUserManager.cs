using ProductPriceTracking.Bll.Helpers;
using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Dto.AppUserDtos;
using ProductPriceTracking.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPriceTracking.Bll.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal dal;
        private readonly IGenericRepository<AppUser> genericdal;
        public AppUserManager(IAppUserDal dal, IGenericRepository<AppUser> genericdal)
        {
            this.dal = dal;
            this.genericdal = genericdal;
        }

        public bool CheckPassword(AppUserLoginDto appUserLoginDto, AppUser appUser)
        {
            return appUser?.Password == ToPasswordRepository.PasswordCryptographyCombine(appUserLoginDto?.Password);
        }

        public async Task<AppUser> FindByUserName(string userName)
        {
            return await genericdal.GetByFilterAsync(x => x.UserName == userName);
        }

        public async Task<ICollection<AppRole>> GetRolesByUserName(string userName)
        {
            return await dal.GetRolesByUserName(userName);
        }
    }
}
