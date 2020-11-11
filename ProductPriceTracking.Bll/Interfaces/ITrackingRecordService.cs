using ProductPriceTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface ITrackingRecordService
    {
        Task<Product> GetLoadedProductById(int productId);
    }
}
