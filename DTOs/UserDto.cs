using System.ComponentModel.DataAnnotations;

namespace cms_webapi.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string Role { get; set; } = string.Empty;
        public DateTime? LastLoginDate { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class CreateUserDto
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
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        
        [StringLength(50)]
        public string Role { get; set; } = "User";
    }

    public class UpdateUserDto
    {
        [StringLength(100)]
        public string? FirstName { get; set; }
        
        [StringLength(100)]
        public string? LastName { get; set; }
        
        [EmailAddress]
        [StringLength(255)]
        public string? Email { get; set; }
        
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        
        [StringLength(50)]
        public string? Role { get; set; }
        
        public bool? IsActive { get; set; }
    }

    public class ChangePasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string NewPassword { get; set; } = string.Empty;
    }
}
