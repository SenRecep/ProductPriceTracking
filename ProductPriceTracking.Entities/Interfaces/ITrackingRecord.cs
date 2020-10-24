using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Entities.Interfaces
{
    public interface ITrackingRecord : IEntityBase
    {
        string Name { get; set; }
        string Url { get; set; }
        int ProductId { get; set; }
        Product Product { get; set; }
    }
}
