using Business.Message.Abstract;
using Entities.Model.DTOS;

namespace Business.Abstract
{
   public interface IAuthService
    {
        Task<IResult> RegisterAsync(RegisterDTO model);
        Task<Core.Entities.Concrete.Token> LoginAsync(string UsernameOrEmail, string password);
    }
}
