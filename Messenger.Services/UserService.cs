using Messenger.Data.Entities;
using Messenger.Services.Defenitions;
using Messenger.Services.Interfaces;
using Messenger.Services.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Messenger.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<ServiceResult<User>> AddPermission(UserPermission permission)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<UserDto>> Authenticate(string userName, string password, bool rememberMe)
        {
            var result =
                await signInManager.PasswordSignInAsync(userName, password, rememberMe, false);

            var user = await userManager.FindByNameAsync(userName);

            if (result.Succeeded)
            {
                var accessToken = await userManager.GenerateUserTokenAsync(user, "Default", "AccessToken");
                var refreshToken = await userManager.GenerateUserTokenAsync(user, "Default", "RefreshToken");

                await userManager.SetAuthenticationTokenAsync(user, "Default", "RefreshToken", refreshToken);
                await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", accessToken);

                return new ServiceResult<UserDto>(new UserDto(user.Id, user.UserName, accessToken, refreshToken));
            }
            else
            {
                return new ServiceResult<UserDto>("invalid username or(and) password");
            }
        }

        public async Task<ServiceResult<User>> Create(User user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return new ServiceResult<User>(user);
            }
            else
            {
                return new ServiceResult<User>(result.Errors.First().Description);
            }
        }

        public Task<ServiceResult<User>> RemovePermission(UserPermission permission)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<User>> RestorePassword(User user)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<User>> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
