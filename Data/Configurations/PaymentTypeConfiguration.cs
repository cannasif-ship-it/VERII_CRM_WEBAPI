using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            // Table name
            builder.ToTable("RII_PAYMENT_TYPE");

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

            builder.Property(e => e.CreatedBy)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(e => e.UpdatedBy)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(e => e.DeletedBy)
                .IsRequired(false)
                .HasMaxLength(100);

            // PaymentType specific properties
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.Description)
                .IsRequired(false)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)");

            // Indexes
            builder.HasIndex(e => e.Name)
                .HasDatabaseName("IX_PaymentType_Name");

            builder.HasIndex(e => e.CreatedDate)
                .HasDatabaseName("IX_PaymentType_CreatedDate");

            // Query filters for soft delete
            builder.HasQueryFilter(e => e.DeletedDate == null);
        }
    }
}
