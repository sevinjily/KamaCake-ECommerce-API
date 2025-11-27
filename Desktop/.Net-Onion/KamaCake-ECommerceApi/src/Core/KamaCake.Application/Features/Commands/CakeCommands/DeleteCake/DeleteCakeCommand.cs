using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaCake.Application.Features.Commands.CakeCommands.DeleteCake
{
    public class DeleteCakeCommand:IRequest<ServiceResponse>
    {
        public Guid Id { get; set; }
        public DeleteCakeCommand(Guid id)
        {
            Id = id;
        }
    }
}
