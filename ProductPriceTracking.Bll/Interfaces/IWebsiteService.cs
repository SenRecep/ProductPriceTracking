using System.Collections.Generic;
using System.Threading.Tasks;

using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface IWebsiteService
    {
        Task<ICollection<Website>> GetWebsites();
    }
}
