﻿using AutoMapper;
using Messenger.Data.Entities;
using Messenger.Services.Interfaces;
using Messenger.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Messenger.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginViewModel model)
        {
            var result = await userService.Authenticate(model.UserName, model.Password, model.RememberMe);
            return Ok(result.Result);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            var result = await userService.Create(mapper.Map<User>(model), model.Password);
            return Ok(result.Result);
        }

    }
}
