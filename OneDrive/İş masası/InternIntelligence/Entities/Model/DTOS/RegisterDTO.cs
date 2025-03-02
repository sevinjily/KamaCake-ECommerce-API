namespace Entities.Model.DTOS
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}   
