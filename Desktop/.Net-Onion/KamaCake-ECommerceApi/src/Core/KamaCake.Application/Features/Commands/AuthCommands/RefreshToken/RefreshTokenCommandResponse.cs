using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaCake.Application.Features.Commands.AuthCommands.RefreshToken
{
    public class RefreshTokenCommandResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
