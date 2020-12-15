using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ProductPriceTracking.Bll.Interfaces;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Concrete
{
    public class UserWebsiteManager : IUserWebsiteService
    {
        private readonly IWebsiteDal websiteDal;

        public UserWebsiteManager(IWebsiteDal websiteDal)
        {
            this.websiteDal = websiteDal;
        }
        public async Task<ICollection<Website>> GetWebsitesByUserId(int userId)
        {
            return await websiteDal.GetWebsitesByUserId(userId);
        }
    }
}
