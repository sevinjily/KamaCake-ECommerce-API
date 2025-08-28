using AutoMapper.Configuration.Annotations;

namespace KamaCake.Application.DTOs.AuthDTOs
{
    public class RegisterDTO
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
