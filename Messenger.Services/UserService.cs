﻿using Messenger.Data.Entities;
using Messenger.Services.Defenitions;
using Messenger.Services.Interfaces;
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

        public async Task<ServiceResult<User>> Authenticate(string userName, string password, bool rememberMe)
        {
            var result =
            await signInManager.PasswordSignInAsync(userName, password, rememberMe, false);

            if (result.Succeeded)
            {
                return new ServiceResult<User>();
            }
            else
            {
                return new ServiceResult<User>("invalid username or(and) password");
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
