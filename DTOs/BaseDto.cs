using System;

namespace cms_webapi.DTOs
{
    public class BaseEntityDto
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedByFullUser { get; set; }
        public string? UpdatedByFullUser { get; set; }
        public string? DeletedByFullUser { get; set; }
    }

    public class BaseHeaderEntityDto : BaseEntityDto
    {
        public string Year { get; set; } = string.Empty;
        public DateTime? CompletionDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsPendingApproval { get; set; } = false;
        public bool? ApprovalStatus { get; set; }
        public string? RejectedReason { get; set; }
        public long? ApprovedByUserId { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public bool IsERPIntegrated { get; set; } = false;
        public string? ERPIntegrationNumber { get; set; }
        public DateTime? LastSyncDate { get; set; }
        public int? CountTriedBy { get; set; } = 0;

    }
}

