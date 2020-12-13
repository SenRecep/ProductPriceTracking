using System.Collections.Generic;

using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Entities.Interfaces
{
    public interface IWebsite : IEntityBase
    {
        string Name { get; set; }
        string BaseUrl { get; set; }
        string IconName { get; set; }
        IEnumerable<PricePosition> PricePositions { get; set; }
    }
}
