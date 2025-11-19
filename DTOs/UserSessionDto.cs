using System;
using System.ComponentModel.DataAnnotations;

namespace cms_webapi.DTOs
{
    public class UserSessionDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public Guid SessionId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? DeviceInfo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class CreateUserSessionDto
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public string Token { get; set; } = string.Empty;
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? DeviceInfo { get; set; }
    }
}