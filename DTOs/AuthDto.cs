using System.ComponentModel.DataAnnotations;

namespace cms_webapi.DTOs
{
    public class LoginDto
    {
        [Required]
        [StringLength(255)]
        public string UsernameOrEmail { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public UserDto User { get; set; } = new UserDto();
    }

    public class RefreshTokenDto
    {
        [Required]
        public string Token { get; set; } = string.Empty;
    }
}
