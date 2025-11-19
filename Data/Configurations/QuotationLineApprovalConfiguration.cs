using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class QuotationLineApprovalConfiguration : BaseEntityConfiguration<QuotationLineApproval>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<QuotationLineApproval> builder)
        {
            builder.ToTable("RII_QUOTATION_LINE_APPROVAL");
            builder.Property(e => e.QuotationLineId).IsRequired();
            builder.Property(e => e.ApproverUserId).IsRequired();
            builder.Property(e => e.ApprovalStatus).HasColumnName("ApprovalStatus");
            builder.Property(e => e.ApprovalNote).HasMaxLength(1000).HasColumnType("nvarchar(1000)");
            builder.HasIndex(e => e.QuotationLineId).HasDatabaseName("IX_QuotationLineApproval_QuotationLineId");
            builder.HasIndex(e => e.ApproverUserId).HasDatabaseName("IX_QuotationLineApproval_ApproverUserId");
            builder.HasIndex(e => e.ApprovalStatus).HasDatabaseName("IX_QuotationLineApproval_Status");
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}