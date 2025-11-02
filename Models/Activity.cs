using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace cms_webapi.Models
{
    [Table("RII_ACTIVITY")]
    public class Activity : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Subject { get; set; } = String.Empty;  // e.g., "Meeting with John Doe"

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [StringLength(50)]
        public string ActivityType { get; set; } = String.Empty;  // e.g., "Call", "Meeting", "Email"

        [ForeignKey("PotentialCustomer")]
        public long? PotentialCustomerId { get; set; }
        public Customer? PotentialCustomer { get; set; }

        public string? ErpCustomerCode { get; set; } = String.Empty;  // e.g., "CUST001"

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = String.Empty;  // e.g., "Scheduled", "Completed", "Canceled"

        public bool IsCompleted { get; set; } = false;

        [StringLength(50)]
        public string? Priority { get; set; }  // "Low", "Medium", "High"

        [ForeignKey("Contact")]
        public long? ContactId { get; set; }
        public Contact? Contact { get; set; }

        [ForeignKey("AssignedUser")]
        public long? AssignedUserId { get; set; }  // CRM Kullanıcısı (sorumlu kişi)
        public User? AssignedUser { get; set; }
    }
}

