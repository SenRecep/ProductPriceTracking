using ProductPriceTracking.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface IWebsiteService
    {
        Task<ICollection<Website>> GetWebsites();
    }
}
