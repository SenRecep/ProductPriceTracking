using System.Threading.Tasks;

using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface IAppRoleService
    {
        Task<AppRole> FindByName(string roleName);
    }
}
