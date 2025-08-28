using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using KamaCake.Application.DTOs.AuthDTOs;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Wrappers.ServiceResponses;
using KamaCake.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
//using Microsoft.AspNetCore.Http;

namespace KamaCake.Application.Features.Commands.AuthCommands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ServiceResponse>
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        private readonly IHttpContextAccessor httpContextAccessors;
        private readonly IUserRepository userRepository;
        private readonly IValidator<RegisterDTO> validator;
        private readonly Guid userId;


        public RegisterCommandHandler(IMapper mapper,UserManager<User> userManager,RoleManager<Role> roleManager,IUserRepository userRepository, IValidator<RegisterDTO> validator, IHttpContextAccessor httpContextAccessors)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.httpContextAccessors = httpContextAccessors;
            this.userRepository = userRepository;
            this.validator = validator;
            userId = Guid.Parse(httpContextAccessors.HttpContext.User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier));
        }
        public async Task<ServiceResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(request.Model, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new ServiceResponse(
                    IsSuccess: false,
                    statusCode: System.Net.HttpStatusCode.BadRequest,
                    message: errors
                );
            }

            var existingUser = userRepository.GetByEmailAsync(request.Model.Email);
            if (existingUser != null)
                return new ServiceResponse
                    (false, System.Net.HttpStatusCode.BadRequest, "Bu email ilə artıq istifadəçi mövcuddur.");

            try
            {
                var user = mapper.Map<User>(request.Model);
                user.SecurityStamp=Guid.NewGuid().ToString();
                user.UserName = request.Model.Email;
                IdentityResult result = await userManager.CreateAsync(user, request.Model.Password);
                //user.PasswordHash=PasswordHasher.HashPassword
                if(await roleManager.RoleExistsAsync("user"))
                {
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });
                }
                await userManager.AddToRoleAsync(user, "user");


                return new ServiceResponse(
               IsSuccess: true,
               statusCode: System.Net.HttpStatusCode.Created,
               message: "Hesab uğurla yaradıldı"
           );
            }
            catch (Exception ex)
            {
                // Əgər hər hansı bir xəta baş verərsə
                return new ServiceResponse(
                    IsSuccess: false,
                    statusCode: System.Net.HttpStatusCode.InternalServerError,
                    message: $"Hesab yaradılmadı: {ex.Message}"
                );


            }

        }
    }
}
