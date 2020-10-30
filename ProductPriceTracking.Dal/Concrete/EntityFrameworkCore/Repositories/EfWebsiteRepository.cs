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
            var result = await context.Websites
                .Where(x => !x.IsDeleted)
                .Include(x => x.Products).Include(x => x.PricePositions)
                .OrderByDescending(x => x.Products.Count())
                .ThenBy(x=>x.Name)
                .ToListAsync();
            Parallel.ForEach(result,x=> {
                x.Products = x.Products.Where(p => !p.IsDeleted);
                x.PricePositions = x.PricePositions.Where(p => !p.IsDeleted);
            });
            return result;
        }
    }
}
