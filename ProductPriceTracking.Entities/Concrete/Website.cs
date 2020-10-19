using ProductPriceTracking.Core.Entities.Concrete;
using ProductPriceTracking.Entities.Interfaces;
using System.Collections.Generic;

namespace ProductPriceTracking.Entities.Concrete
{
    public class Website : EntityBase, IWebsite
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string IconName { get; set; }
        public IEnumerable<PricePosition> PricePositions { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
