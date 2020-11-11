using Microsoft.EntityFrameworkCore;
using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Contexts;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Entities.Concrete;
using System.Threading.Tasks;

namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class EfTrackingRecordRepository : ITrackingRecordDal
    {
        private readonly ProductPriceTrackingDbContext context;

        public EfTrackingRecordRepository(ProductPriceTrackingDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetLoadedProductById(int productId)
        {
            return await context.Products
                .Include(x => x.TrackingRecords).Include(x => x.Website)
                .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == productId);
        }
    }
}
