using System.Threading.Tasks;

using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface ITrackingRecordService
    {
        Task<Product> GetLoadedProductById(int productId);
    }
}
