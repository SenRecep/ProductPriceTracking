using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Entities.Interfaces
{
    public interface IUserRole : IEntityBase
    {
        int AppUserId { get; set; }
        int AppRoleId { get; set; }

        AppUser AppUser { get; set; }
        AppRole AppRole { get; set; }
    }
}
