using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

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
