using ProductPriceTracking.Core.Entities.Concrete;
using ProductPriceTracking.Entities.Interfaces;

namespace ProductPriceTracking.Entities.Concrete
{
    public class UserRole : EntityBase, IUserRole
    {
        public int AppUserId { get; set; }
        public int AppRoleId { get; set; }

        public AppUser AppUser { get; set; }
        public AppRole AppRole { get; set; }
    }
}
