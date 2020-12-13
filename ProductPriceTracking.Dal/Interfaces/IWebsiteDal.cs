using System.Collections.Generic;
using System.Threading.Tasks;

using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Dal.Interfaces
{
    public interface IWebsiteDal
    {
        Task<ICollection<Website>> GetWebsites();
    }
}
