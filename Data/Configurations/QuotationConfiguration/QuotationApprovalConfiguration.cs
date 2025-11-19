using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class QuotationApprovalConfiguration : BaseEntityConfiguration<QuotationApproval>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<QuotationApproval> builder)
        {
            builder.ToTable("RII_QUOTATION_APPROVAL");
            builder.Property(e => e.QuotationId).IsRequired();
            builder.Property(e => e.ApproverUserId).IsRequired();
            builder.Property(e => e.ApprovalStatus).HasColumnName("ApprovalStatus");
            builder.Property(e => e.ApprovalNote).HasMaxLength(500).HasColumnType("nvarchar(500)");
            builder.HasIndex(e => e.QuotationId).HasDatabaseName("IX_QuotationApproval_QuotationId");
            builder.HasIndex(e => e.ApproverUserId).HasDatabaseName("IX_QuotationApproval_ApproverUserId");
            builder.HasIndex(e => e.ApprovalStatus).HasDatabaseName("IX_QuotationApproval_Status");
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}