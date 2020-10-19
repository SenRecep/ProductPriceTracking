using ProductPriceTracking.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPriceTracking.Dal.Interfaces
{
    public interface IAppUserDal
    {
        Task<ICollection<AppRole>> GetRolesByUserName(string userName);
    }
}
