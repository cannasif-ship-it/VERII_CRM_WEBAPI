using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_webapi.Models
{
    [Table("RII_CONTACT")]
    public class Contact : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }  = string.Empty; // e.g. John Doe

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(20)]
        public string? Mobile { get; set; }

        [StringLength(250)]
        public string? Notes { get; set; }  // Additional remarks or relationship context

        // Foreign Key
        public long CustomerId { get; set; }
        // Navigation property
        public virtual Customer Customers { get; set; } = null!;

        // Foreign Key
        public long TitleId { get; set; }
        // Navigation property
        [ForeignKey("TitleId")]
        public virtual Title Titles { get; set; } = null!;
    }
}
