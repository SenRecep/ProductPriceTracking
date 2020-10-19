using ProductPriceTracking.Entities.Concrete;
using System.Threading.Tasks;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface IAppRoleService
    {
        Task<AppRole> FindByName(string roleName);
    }
}
