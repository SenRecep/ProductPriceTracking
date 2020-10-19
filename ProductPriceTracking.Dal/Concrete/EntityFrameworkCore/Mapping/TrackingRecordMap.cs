using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class TrackingRecordMap : IEntityTypeConfiguration<TrackingRecord>
    {
        public void Configure(EntityTypeBuilder<TrackingRecord> builder)
        {
            builder.EntityBaseMap();
            builder.EntityUniqueString(x => x.Url, 300);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
