using KamaCake.Application.DTOs.AuthDTOs;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaCake.Application.Features.Commands.AuthCommands.Register
{
    public class RegisterCommand:IRequest<ServiceResponse>
    {
        public RegisterDTO Model { get; set; }
        public RegisterCommand(RegisterDTO model)
        {
            Model = model;
        }

    }
}
