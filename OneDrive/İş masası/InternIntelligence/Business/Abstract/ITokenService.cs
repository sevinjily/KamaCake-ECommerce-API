using Core.Entities.Concrete;

namespace Business.Abstract
{
   public interface ITokenService
    {
        Task<Token> CreateAccessToken();
    }
}
 