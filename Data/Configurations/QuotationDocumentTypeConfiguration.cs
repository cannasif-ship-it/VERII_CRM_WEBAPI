using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class QuotationDocumentTypeConfiguration : BaseEntityConfiguration<QuotationDocumentType>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<QuotationDocumentType> builder)
        {
            builder.ToTable("RII_QUOTATION_DOCUMENT_TYPE");
            builder.Property(e => e.DocumentTypeName)
                .HasMaxLength(30)
                .HasColumnType("nvarchar(30)")
                .IsRequired();
            builder.Property(e => e.customerTypeId)
                .IsRequired();
            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)");
            builder.HasIndex(e => e.DocumentTypeName)
                .IsUnique()
                .HasDatabaseName("IX_QuotationDocumentType_Name");
            builder.HasIndex(e => e.customerTypeId)
                .HasDatabaseName("IX_QuotationDocumentType_CustomerTypeId");
            builder.HasOne< CustomerType >()
                .WithMany()
                .HasForeignKey(e => e.customerTypeId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}