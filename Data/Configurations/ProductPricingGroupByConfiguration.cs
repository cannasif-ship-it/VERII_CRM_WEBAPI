using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class ProductPricingGroupByConfiguration : IEntityTypeConfiguration<ProductPricingGroupBy>
    {
        public void Configure(EntityTypeBuilder<ProductPricingGroupBy> builder)
        {
            // Table name
            builder.ToTable("RII_PRODUCT_PRICING_GROUP_BY");

            // Primary key
            builder.HasKey(e => e.Id);

            // Base entity configuration
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")
                .IsRequired();

            builder.Property(e => e.UpdatedDate)
                .HasColumnName("UpdatedDate")
                .IsRequired(false);

            builder.Property(e => e.DeletedDate)
                .HasColumnName("DeletedDate")
                .IsRequired(false);

            builder.Property(e => e.IsDeleted)
                .HasColumnName("IsDeleted")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CreatedBy")
                .IsRequired(false);

            builder.Property(e => e.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .IsRequired(false);

            builder.Property(e => e.DeletedBy)
                .HasColumnName("DeletedBy")
                .IsRequired(false);

            // Specific properties
            builder.Property(e => e.ErpGroupCode)
                .HasColumnName("ErpGroupCode")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Currency)
                .HasColumnName("Currency")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.ListPrice)
                .HasColumnType("decimal(18,6)")
                .IsRequired();

            builder.Property(e => e.CostPrice)
                .HasColumnType("decimal(18,6)")
                .IsRequired();

            builder.Property(e => e.Discount1)
                .HasColumnType("decimal(18,6)")
                .IsRequired(false);

            builder.Property(e => e.Discount2)
                .HasColumnType("decimal(18,6)")
                .IsRequired(false);

            builder.Property(e => e.Discount3)
                .HasColumnType("decimal(18,6)")
                .IsRequired(false);

            // Indexes
            builder.HasIndex(e => e.ErpGroupCode)
                .HasDatabaseName("IX_ProductPricingGroupBy_ErpGroupCode")
                .IsUnique();

            builder.HasIndex(e => e.IsDeleted)
                .HasDatabaseName("IX_ProductPricingGroupBy_IsDeleted");

            builder.HasIndex(e => e.CreatedBy)
                .HasDatabaseName("IX_RII_PRODUCT_PRICING_GROUP_BY_CreatedBy");

            builder.HasIndex(e => e.UpdatedBy)
                .HasDatabaseName("IX_RII_PRODUCT_PRICING_GROUP_BY_UpdatedBy");

            builder.HasIndex(e => e.DeletedBy)
                .HasDatabaseName("IX_RII_PRODUCT_PRICING_GROUP_BY_DeletedBy");

            // Query filter for soft delete
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
