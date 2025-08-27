using AutoMapper;
using KamaCake.Application.Wrappers.ServiceResponses;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace KamaCake.Application.Features.Commands.AuthCommands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ServiceResponse>
    {
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessors;
        private readonly Guid userId;

        public RegisterCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessors)
        {
            this.mapper = mapper;
            this.httpContextAccessors = httpContextAccessors;
            userId = Guid.Parse(httpContextAccessors.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public Task<ServiceResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if(request.Model is not null)
        }
    }
}
