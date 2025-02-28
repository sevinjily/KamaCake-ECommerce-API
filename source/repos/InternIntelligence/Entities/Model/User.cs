using Microsoft.AspNet.Identity.EntityFramework;
using System.Text.Json.Serialization;

namespace Entities.Model
{
   public class User:IdentityUser
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public  string UserNameOrEmail { get; set; }
        public string Password { get; set; }

    }
}
