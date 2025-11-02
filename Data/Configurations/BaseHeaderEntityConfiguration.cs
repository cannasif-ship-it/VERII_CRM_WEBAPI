using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class BaseHeaderEntityConfiguration : IEntityTypeConfiguration<BaseHeaderEntity>
    {
        public void Configure(EntityTypeBuilder<BaseHeaderEntity> builder)
        {
            // This is an abstract class, so we configure common properties
            // that will be inherited by concrete entities

            // Completion Date properties
            builder.Property(e => e.CompletionDate)
                .IsRequired(false);

            builder.Property(e => e.IsCompleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Approval Fields
            builder.Property(e => e.IsPendingApproval)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(e => e.ApprovalStatus)
                .IsRequired(false);

            builder.Property(e => e.ApprovedByUserId)
                .IsRequired(false);

            builder.Property(e => e.ApprovalDate)
                .IsRequired(false);

            // ERP Integration properties
            builder.Property(e => e.IsERPIntegrated)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(e => e.ERPIntegrationNumber)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(e => e.LastSyncDate)
                .IsRequired(false);

            builder.Property(e => e.CountTriedBy)
                .IsRequired(false)
                .HasDefaultValue(0);

            // Indexes for performance
            builder.HasIndex(e => e.IsCompleted);
            builder.HasIndex(e => e.IsPendingApproval);
            builder.HasIndex(e => e.ApprovalStatus);
            builder.HasIndex(e => e.IsERPIntegrated);
            builder.HasIndex(e => e.ERPIntegrationNumber);
        }
    }
}
