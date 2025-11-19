using System;
using System.ComponentModel.DataAnnotations;

namespace cms_webapi.DTOs
{
    public class ApprovalWorkflowDto
    {
        public long Id { get; set; }
        public string DocumentType { get; set; } = string.Empty;
        public long? UserId { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class CreateApprovalWorkflowDto
    {
        [MaxLength(50)]
        public string DocumentType { get; set; } = "QUOTATION";
        public long? UserId { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
    }

    public class UpdateApprovalWorkflowDto
    {
        [MaxLength(50)]
        public string DocumentType { get; set; } = "QUOTATION";
        public long? UserId { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
    }
}