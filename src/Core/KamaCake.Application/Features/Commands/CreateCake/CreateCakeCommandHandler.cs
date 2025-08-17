using KamaCake.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaCake.Application.Features.Commands.CreateProduct
{
    public class CreateCakeCommandHandler : IRequestHandler<CreateCakeCommand, ServiceResponse<Guid>>
    {
        public Task<ServiceResponse<Guid>> Handle(CreateCakeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
