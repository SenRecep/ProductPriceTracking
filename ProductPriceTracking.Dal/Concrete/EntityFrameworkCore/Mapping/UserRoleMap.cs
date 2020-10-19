using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.EntityBaseMap();

            builder.HasIndex(x => new { x.AppUserId, x.AppRoleId });

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.AppRole)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.AppRoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
