using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class ProductPricingConfiguration : IEntityTypeConfiguration<ProductPricing>
    {
        public void Configure(EntityTypeBuilder<ProductPricing> builder)
        {
            // Table name
            builder.ToTable("RII_PRODUCT_PRICING");

            // Primary key
            builder.HasKey(e => e.Id);

            // Base properties configuration
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.UpdatedDate)
                .IsRequired(false);

            builder.Property(e => e.DeletedDate)
                .IsRequired(false);

            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            // ProductPricing specific properties
            builder.Property(e => e.ErpProductCode)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.ErpGroupCode)
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
            builder.HasIndex(e => e.ErpProductCode)
                .HasDatabaseName("IX_ProductPricing_ErpProductCode");

            builder.HasIndex(e => e.ErpGroupCode)
                .HasDatabaseName("IX_ProductPricing_ErpGroupCode");

            builder.HasIndex(e => new { e.ErpProductCode, e.ErpGroupCode })
                .HasDatabaseName("IX_ProductPricing_ErpProductCode_ErpGroupCode")
                .IsUnique();

            builder.HasIndex(e => e.IsDeleted)
                .HasDatabaseName("IX_ProductPricing_IsDeleted");

            builder.HasIndex(e => e.CreatedDate)
                .HasDatabaseName("IX_ProductPricing_CreatedDate");

            // Query filter for soft delete
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
