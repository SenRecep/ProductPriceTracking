using Microsoft.EntityFrameworkCore;
using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Contexts;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWebsiteRepository : IWebsiteDal
    {
        private readonly ProductPriceTrackingDbContext context;

        public EfWebsiteRepository(ProductPriceTrackingDbContext context)
        {
            this.context = context;
        }
        public async Task<ICollection<Website>> GetWebsites()
        {
            return await context.Websites
                .Where(x => !x.IsDeleted)
                .Include(x => x.Products).Include(x => x.PricePositions)
                .ToListAsync();
        }
    }
}
