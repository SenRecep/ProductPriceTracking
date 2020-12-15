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
        private readonly IGenericRepository<Product> productRepository;

        public WebsiteManager(IWebsiteDal websiteDal, IGenericRepository<Product> productRepository)
        {
            this.websiteDal = websiteDal;
            this.productRepository = productRepository;
        }

        public async Task<ICollection<Product>> GetProductsByWebsiteId(int websiteId)
        {
            return await productRepository.GetAllByFilterNotDeletedAsync(x=>x.WebsiteId==websiteId);
        }

        public Task<ICollection<Website>> GetWebsites()
        {
            return websiteDal.GetWebsites();
        }
     
        public async Task<ICollection<Website>> GetWebsitesByUserId(int userId)
        {
            return await websiteDal.GetWebsitesByUserId(userId);
        }
    }
}
