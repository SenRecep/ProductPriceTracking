using ProductPriceTracking.Core.Entities.Concrete;
using ProductPriceTracking.Entities.Interfaces;

namespace ProductPriceTracking.Entities.Concrete
{
    public class TrackingRecord : EntityBase, ITrackingRecord
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
