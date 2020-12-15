using System.Collections.Generic;
using System.Threading.Tasks;

using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface IUserWebsiteService
    {
       Task<ICollection<Website>> GetWebsitesByUserId(int userId);
    }
}
