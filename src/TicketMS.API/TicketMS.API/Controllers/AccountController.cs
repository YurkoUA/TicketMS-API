using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMS.API.Filters;
using TicketMS.API.Infrastructure.Common.Models.Security;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels.Account;
using TicketMS.API.ViewModels.User;

namespace TicketMS.API.Controllers
{
    public class AccountController : ApplicationController
    {
        private readonly IUserAuthenticationService authenticationService;
        private readonly IUserService userService;

        public AccountController(IMappingService mappingService, 
            IUserAuthenticationService userAuthenticationService,
            IUserService userService) : base(mappingService)
        {
            authenticationService = userAuthenticationService;
            this.userService = userService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Account()
        {
            var user = mapper.ConvertTo<UserVM>(userService.FindUser(UserToken.UserId));
            return Ok(user);
        }

        [HttpPost("SignIn")]
        [ValidateModel]
        public IActionResult SignIn([FromBody]SignInRequestVM model)
        {
            JsonWebToken token = authenticationService.Authenticate(model.Login, model.Password, out UserVM user);
            return Ok(new SignInResponseVM
            {
                Token = token,
                User = user
            });
        }
    }
}