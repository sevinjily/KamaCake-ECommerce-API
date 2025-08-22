using KamaCake.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace KamaCake.Domain.Entities
{
    public class User:IdentityUser<Guid>

    {
        public string FullName { get; set; }
        public string? ResfreshToken { get; set; }
        public DateTime? ResfreshTokenExpiryTime { get; set; }
        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        //public string? Address { get; set; }
        //public DateTime? BirthDate { get; set; }
        //public string? ProfileImageUrl { get; set; }
    }
}
