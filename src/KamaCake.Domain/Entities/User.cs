using KamaCake.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace KamaCake.Domain.Entities
{
    public class User:IdentityUser<Guid>

    {
        public string FullName { get; set; }
        public string? ResfreshToken { get; set; }
        public DateTime? ResfreshTokenExpiryTime { get; set; }
      
    }
}
