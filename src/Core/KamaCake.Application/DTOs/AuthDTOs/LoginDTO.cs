using System.ComponentModel;

namespace KamaCake.Application.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        [DefaultValue("akbar@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("Akbar123_")]
        public string Password { get; set; }
    }
}
