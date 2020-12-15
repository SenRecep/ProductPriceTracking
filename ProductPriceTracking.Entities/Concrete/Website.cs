using System.Collections.Generic;

using ProductPriceTracking.Core.Entities.Concrete;
using ProductPriceTracking.Entities.ExtensionMethods;
using ProductPriceTracking.Entities.Interfaces;

namespace ProductPriceTracking.Entities.Concrete
{
    public class Website : EntityBase, IWebsite
    {
        public Website()
        {

        }
        public Website(Website website)
        {
            EntityDataTransfer.DataTransfer(this,website);
        }

        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string IconName { get; set; }
        public IEnumerable<PricePosition> PricePositions { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<TrackingRecord> TrackingRecords { get; set; }
        public IEnumerable<UserWebsite> UserWebsites { get; set; }
    }
}
