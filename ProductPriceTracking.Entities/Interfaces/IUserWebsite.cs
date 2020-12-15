using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Entities.Interfaces
{
    public interface IUserWebsite:IEntityBase
    {
        AppUser AppUser { get; set; }
        int AppUserId { get; set; }
        Website Website { get; set; }
        int WebsiteId { get; set; }
    }
}