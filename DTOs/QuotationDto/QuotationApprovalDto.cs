using System;
using System.ComponentModel.DataAnnotations;

namespace cms_webapi.DTOs
{
    public class QuotationApprovalDto : BaseEntityDto
    {
        public long QuotationId { get; set; }
        public long ApproverUserId { get; set; }
        public int ApprovalStatus { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? ApprovalNote { get; set; }
    }

    public class CreateQuotationApprovalDto
    {
        [Required]
        public long QuotationId { get; set; }
        [Required]
        public long ApproverUserId { get; set; }
        public int ApprovalStatus { get; set; } = 0;
        public DateTime? ApprovalDate { get; set; }
        [MaxLength(500)]
        public string? ApprovalNote { get; set; }
    }

    public class UpdateQuotationApprovalDto
    {
        public long ApproverUserId { get; set; }
        public int ApprovalStatus { get; set; }
        public DateTime? ApprovalDate { get; set; }
        [MaxLength(500)]
        public string? ApprovalNote { get; set; }
    }
}
