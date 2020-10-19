using ProductPriceTracking.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPriceTracking.Dal.Interfaces
{
    public interface IWebsiteDal
    {
        Task<ICollection<Website>> GetWebsites();
    }
}
