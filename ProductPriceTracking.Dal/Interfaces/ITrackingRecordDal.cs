using System.Threading.Tasks;

using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Dal.Interfaces
{
    public interface ITrackingRecordDal
    {
        Task<Product> GetLoadedProductById(int productId);
    }
}
