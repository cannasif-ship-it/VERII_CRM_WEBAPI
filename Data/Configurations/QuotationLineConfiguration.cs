using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class QuotationLineConfiguration : BaseEntityConfiguration<QuotationLine>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<QuotationLine> builder)
        {
            // Table
            builder.ToTable("RII_QUOTATION_LINE");

            // Properties
            builder.Property(e => e.ProductCode)
                .HasMaxLength(100)
                .IsRequired(false);

            

            // Decimal precisions are defined via [Column(TypeName = "decimal(18,6)")] in the model
            // Relationships
            builder.Property(e => e.QuotationId)
                .IsRequired();

            builder.HasOne(e => e.Quotation)
                .WithMany()
                .HasForeignKey(e => e.QuotationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes for common queries
            builder.HasIndex(e => e.QuotationId)
                .HasDatabaseName("IX_QuotationLine_QuotationId");

            builder.HasIndex(e => e.ProductCode)
                .HasDatabaseName("IX_QuotationLine_ProductCode");

            builder.HasIndex(e => e.IsDeleted)
                .HasDatabaseName("IX_QuotationLine_IsDeleted");
        }
    }
}