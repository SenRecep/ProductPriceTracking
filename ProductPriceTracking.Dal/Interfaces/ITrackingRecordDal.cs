using ProductPriceTracking.Entities.Concrete;
using System.Threading.Tasks;

namespace ProductPriceTracking.Dal.Interfaces
{
    public interface ITrackingRecordDal
    {
        Task<Product> GetLoadedProductById(int productId);
    }
}
