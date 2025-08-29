namespace KamaCake.Application.Features.Commands.AuthCommands.Login
{
    public class LoginCommandResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }//refresh tokenin bitme vaxti
    }
}
