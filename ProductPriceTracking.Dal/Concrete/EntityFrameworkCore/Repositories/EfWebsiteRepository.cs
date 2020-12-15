using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Contexts;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Entities.Concrete;

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
            List<Website> result = await context.Websites
                .Where(x => !x.IsDeleted)
                .Include(x => x.Products).Include(x => x.PricePositions)
                .OrderByDescending(x => x.Products.Count())
                .ThenBy(x => x.Name)
                .ToListAsync();
            Parallel.ForEach(result, x =>
            {
                x.Products = x.Products.Where(p => !p.IsDeleted).ToList();
                x.PricePositions = x.PricePositions.Where(p => !p.IsDeleted).ToList();
            });
            return result;
        }

        public async Task<ICollection<Website>> GetWebsitesByUserId(int userId)
        {
            var result = await context.AppUsers.Join(context.UserWebsites, u => u.Id, uw => uw.AppUserId, (user, userWebsite) => new
            {
                User = user,
                UserWebsite = userWebsite
            }).Join(context.Websites
            .Include(x => x.Products).ThenInclude(x=>x.TrackingRecords).ThenInclude(x=>x.Website).ThenInclude(x=>x.PricePositions)
            .Include(x => x.PricePositions),
            uw => uw.UserWebsite.WebsiteId, w => w.Id, (UW, W) => new
            {
                User = UW.User,
                UserWebsite = UW.UserWebsite,
                Website = W
            }).Where(x => x.User.Id == userId && !x.UserWebsite.IsDeleted && !x.User.IsDeleted && !x.Website.IsDeleted)
            .Select(x => new Website(x.Website))
            .ToListAsync();
            Parallel.ForEach(result, x =>
            {
                x.Products = x.Products.Where(p => !p.IsDeleted).ToList();
                x.PricePositions = x.PricePositions.Where(p => !p.IsDeleted).ToList();
            });
            return result;
        }
    }
}
