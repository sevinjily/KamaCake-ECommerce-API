using Business.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TokenManager : ITokenService
    {
        public Task<Token> CreateAccessToken()
        {
            throw new NotImplementedException();
        }
    }
}
