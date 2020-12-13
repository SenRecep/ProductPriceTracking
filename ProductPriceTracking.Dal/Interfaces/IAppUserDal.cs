using System.Collections.Generic;
using System.Threading.Tasks;

using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Dal.Interfaces
{
    public interface IAppUserDal
    {
        Task<ICollection<AppRole>> GetRolesByUserName(string userName);
    }
}
