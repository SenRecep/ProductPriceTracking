using System.Collections.Generic;

using ProductPriceTracking.Core.Entities.Concrete;
using ProductPriceTracking.Entities.Interfaces;

namespace ProductPriceTracking.Entities.Concrete
{
    public class AppRole : EntityBase, IAppRole
    {
        public AppRole() { }
        public AppRole(AppRole appRole)
        {
            Id = appRole.Id;
            Name = appRole.Name;
            CreateDate = appRole.CreateDate;
            CreateUserId = appRole.CreateUserId;
            IsDeleted = appRole.IsDeleted;
            UpdateDate = appRole.UpdateDate;
            UpdateUserId = appRole.UpdateUserId;
        }
        public string Name { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
