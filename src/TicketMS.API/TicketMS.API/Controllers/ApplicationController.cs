using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Models;

namespace TicketMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        public UserToken UserToken { get;  }
        protected readonly IMappingService mapper;

        public ApplicationController(IMappingService mappingService)
        {
            mapper = mappingService;
            ConfigureUserId();
        }

        [NonAction]
        public IActionResult BadRequestWithErrors(params string[] errors)
        {
            return BadRequest(errors);
        }

        #region Private methods.

        private void ConfigureUserId()
        {
            string strId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var success = int.TryParse(strId, out int id);

            if (!success)
                throw new InvalidOperationException();

            UserToken.UserId = id;
        }

        #endregion
    }
}