using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Entities.Concrete;
using System.Threading.Tasks;

namespace ProductPriceTracking.Bll.Concrete
{
    public class AppRoleManager : IAppRoleService
    {
        private readonly IGenericRepository<AppRole> dal;
        public AppRoleManager(IGenericRepository<AppRole> dal)
        {
            this.dal = dal;
        }

        public async Task<AppRole> FindByName(string roleName)
        {
            return await dal.GetByFilterAsync(x => x.Name == roleName);
        }
    }
}
