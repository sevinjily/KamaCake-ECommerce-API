using Microsoft.AspNet.Identity.EntityFramework;

namespace Entities.Model
{
   public class AppUser:IdentityUser
    {
        //[JsonIgnore]
        //public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? OTP { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public int FailedAttempts { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiredDate { get; set; }


        //public  string UserNameOrEmail { get; set; }

    }
}
