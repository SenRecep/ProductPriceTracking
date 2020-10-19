using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Entities.Concrete;
using System.Collections.Generic;

namespace ProductPriceTracking.Entities.Interfaces
{
    public interface IAppUser : IEntityBase
    {
        string UserName { get; set; }
        string FullName { get; set; }
        string Password { get; set; }
        IEnumerable<UserRole> UserRoles { get; set; }
    }
}
