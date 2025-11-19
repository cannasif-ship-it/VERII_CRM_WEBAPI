using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class ApprovalWorkflowConfiguration : BaseEntityConfiguration<ApprovalWorkflow>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ApprovalWorkflow> builder)
        {
            builder.ToTable("RII_APPROVAL_WORKFLOW");
            builder.Property(e => e.DocumentType).HasMaxLength(50).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.UserId).IsRequired(false);
            builder.Property(e => e.MinAmount).HasColumnType("decimal(18,6)");
            builder.Property(e => e.MaxAmount).HasColumnType("decimal(18,6)");
            builder.HasIndex(e => e.DocumentType).HasDatabaseName("IX_ApprovalWorkflow_DocumentType");
            builder.HasIndex(e => e.UserId).HasDatabaseName("IX_ApprovalWorkflow_UserId");
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}