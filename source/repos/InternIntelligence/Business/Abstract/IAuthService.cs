using Core.Entities;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    interface IAuthService
    {
        Task<Token> LoginAsync(string UsernameOrEmail, string password);
    }
}
