using Business.Abstract;
using Business.Message.Abstract;
using Business.Message.Concrete.ErrorResult;
using Business.Message.Concrete.SuccessResult;
using Core.Entities.Concrete;
using Entities.Model;
using Entities.Model.DTOS;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthManager(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<Token> LoginAsync(string UsernameOrEmail, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RegisterAsync(RegisterDTO model)
        {
            AppUser user = new()
            {
                FirstName = model.FirstName,
                LastName = model.Lastname,
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed=false
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
                return new SuccessResult("User created", System.Net.HttpStatusCode.Created);

            else
            {
                string response = string.Empty;
                foreach (var error in result.Errors)
                {
                    response += error.Description + ".";
                }
                return new ErrorResult(response, HttpStatusCode.BadRequest);

            }


        }
    }
}
