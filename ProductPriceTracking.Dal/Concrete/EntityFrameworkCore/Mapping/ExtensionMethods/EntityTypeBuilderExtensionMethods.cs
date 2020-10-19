using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductPriceTracking.Core.Entities.Interfaces;
using System;
using System.Linq.Expressions;


namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods
{
    public static class EntityTypeBuilderExtensionMethods
    {
        public static void EntityUniqueString<TEntity>(this EntityTypeBuilder<TEntity> builder, Expression<Func<TEntity, object>> property, int maxLength = 100)
            where TEntity : class, IEntityBase, new()
        {
            builder.Property(property)
               .HasMaxLength(maxLength)
               .IsRequired();

            builder.HasIndex(property)
                .IsUnique();
        }

        public static void EntityBaseMap<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class, IEntityBase, new()
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()").IsRequired();
            builder.Property(x => x.CreateUserId).HasDefaultValue(0).IsRequired();

            builder.Property(x => x.UpdateDate).IsRequired(false);
            builder.Property(x => x.UpdateUserId).IsRequired(false);

            builder.Property(I => I.IsDeleted).HasDefaultValue(false).IsRequired();
        }
    }
}
