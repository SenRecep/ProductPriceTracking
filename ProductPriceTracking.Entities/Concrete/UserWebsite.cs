using ProductPriceTracking.Core.Entities.Concrete;
using ProductPriceTracking.Entities.Interfaces;

namespace ProductPriceTracking.Entities.Concrete
{
    public class UserWebsite : EntityBase,IUserWebsite
    {
        public int AppUserId { get; set; }
        public int WebsiteId { get; set; }
        public AppUser AppUser { get; set; }
        public Website Website { get; set; }
    }
}
