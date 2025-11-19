using System;
using System.ComponentModel.DataAnnotations;

namespace cms_webapi.DTOs
{
    public class QuotationLineApprovalDto
    {
        public long Id { get; set; }
        public long QuotationLineId { get; set; }
        public long ApproverUserId { get; set; }
        public int ApprovalStatus { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? ApprovalNote { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class CreateQuotationLineApprovalDto
    {
        [Required]
        public long QuotationLineId { get; set; }
        [Required]
        public long ApproverUserId { get; set; }
        public int ApprovalStatus { get; set; } = 0;
        public DateTime? ApprovalDate { get; set; }
        [MaxLength(1000)]
        public string? ApprovalNote { get; set; }
    }

    public class UpdateQuotationLineApprovalDto
    {
        public long ApproverUserId { get; set; }
        public int ApprovalStatus { get; set; }
        public DateTime? ApprovalDate { get; set; }
        [MaxLength(1000)]
        public string? ApprovalNote { get; set; }
    }
}