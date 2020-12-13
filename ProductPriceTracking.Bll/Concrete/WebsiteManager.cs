using System.Collections.Generic;
using System.Threading.Tasks;

using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Concrete
{
    public class WebsiteManager : IWebsiteService
    {
        private readonly IWebsiteDal websiteDal;

        public WebsiteManager(IWebsiteDal websiteDal)
        {
            this.websiteDal = websiteDal;
        }

        public Task<ICollection<Website>> GetWebsites()
        {
            return websiteDal.GetWebsites();
        }
    }
}
