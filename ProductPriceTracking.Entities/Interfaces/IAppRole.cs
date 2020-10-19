using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Entities.Concrete;
using System.Collections.Generic;

namespace ProductPriceTracking.Entities.Interfaces
{
    public interface IAppRole : IEntityBase
    {
        string Name { get; set; }
        IEnumerable<UserRole> UserRoles { get; set; }
    }
}
