using ProductPriceTracking.Core.Entities.Concrete;
using ProductPriceTracking.Entities.Interfaces;

namespace ProductPriceTracking.Entities.Concrete
{
    public class PricePosition : EntityBase, IPricePosition
    {
        public string XPath { get; set; }
        public int Priority { get; set; }
        public int WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
