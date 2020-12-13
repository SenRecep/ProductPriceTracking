using System.Collections.Generic;

using ProductPriceTracking.Core.Entities.Interfaces;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Entities.Interfaces
{
    public interface IAppRole : IEntityBase
    {
        string Name { get; set; }
        IEnumerable<UserRole> UserRoles { get; set; }
    }
}
