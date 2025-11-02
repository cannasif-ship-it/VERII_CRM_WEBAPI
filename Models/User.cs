
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

﻿namespace cms_webapi.Models
{
    [Table("RII_USER")]
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        
        [StringLength(50)]
        public string Role { get; set; } = "User";
        
        public DateTime? LastLoginDate { get; set; }
        
        public bool IsEmailConfirmed { get; set; } = false;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
