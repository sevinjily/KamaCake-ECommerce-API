using Business.Abstract;
using Core.Entities;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        public Task<Token> LoginAsync(string UsernameOrEmail, string password)
        {
            throw new NotImplementedException();
        }
    }
}
