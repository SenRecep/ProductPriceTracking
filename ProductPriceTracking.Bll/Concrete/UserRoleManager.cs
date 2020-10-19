using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Entities.Concrete;
using System.Threading.Tasks;

namespace ProductPriceTracking.Bll.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IGenericRepository<UserRole> dal;
        public UserRoleManager(IGenericRepository<UserRole> dal)
        {
            this.dal = dal;
        }

        public async Task<bool> CheckUserRole(int userId, int roleId)
        {
            return await dal.GetByFilterAsync(x => x.AppUserId == userId && x.AppRoleId == roleId) != null;
        }
    }
}
