using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Contexts;
using ProductPriceTracking.Dal.Interfaces;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        private readonly ProductPriceTrackingDbContext context;

        public EfAppUserRepository(ProductPriceTrackingDbContext context)
        {
            this.context = context;
        }
        public async Task<ICollection<AppRole>> GetRolesByUserName(string userName)
        {
            return await context.AppUsers.Join(context.UserRoles, u => u.Id, ur => ur.AppUserId, (user, userRole) => new
            {
                User = user,
                UserRole = userRole
            }).Join(context.AppRoles, ur => ur.UserRole.AppRoleId, r => r.Id, (userAndUserRole, role) => new
            {
                User = userAndUserRole.User,
                Role = role
            }).Where(t => t.User.UserName.Equals(userName))
              .Select(t => new AppRole(t.Role))
              .ToListAsync();
        }
    }
}
