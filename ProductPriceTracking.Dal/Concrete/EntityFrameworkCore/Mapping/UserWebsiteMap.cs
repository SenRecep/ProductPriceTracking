using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class UserWebsiteMap : IEntityTypeConfiguration<UserWebsite>
    {
        public void Configure(EntityTypeBuilder<UserWebsite> builder)
        {
            builder.EntityBaseMap();
            builder.HasIndex(x => new { x.AppUserId, x.WebsiteId });

            builder.HasOne(x=>x.Website)
                .WithMany(x=>x.UserWebsites)
                .HasForeignKey(x=>x.WebsiteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.AppUser)
              .WithMany(x => x.UserWebsites)
              .HasForeignKey(x=>x.AppUserId)
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
