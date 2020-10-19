using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Entities.Interfaces
{
    public interface IPricePosition : IEntityBase
    {
         string XPath { get; set; }
         int Priority { get; set; }
         int WebsiteId { get; set; }
         Website Website { get; set; }
    }
}
