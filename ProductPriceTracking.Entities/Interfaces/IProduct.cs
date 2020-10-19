using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Entities.Interfaces
{
    public interface IProduct : IEntityBase
    {
        string Name { get; set; }
        string Url { get; set; }
        int WebsiteId { get; set; }
        Website Website { get; set; }
    }
}
