using System.Collections.Generic;

using ProductPriceTracking.Core.Entities.Concrete;
using ProductPriceTracking.Entities.ExtensionMethods;
using ProductPriceTracking.Entities.Interfaces;

namespace ProductPriceTracking.Entities.Concrete
{
    public class AppRole : EntityBase, IAppRole
    {
        public AppRole() { }
        public AppRole(AppRole appRole)
        {
            EntityDataTransfer.DataTransfer(this, appRole);
        }
        public string Name { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
