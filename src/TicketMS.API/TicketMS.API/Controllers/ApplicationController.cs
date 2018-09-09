using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Models;
using TicketMS.API.ViewModels.Primitives;

namespace TicketMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
        public UserToken UserToken { get; } = new UserToken();
        protected readonly IMappingService mapper;

        public ApplicationController(IMappingService mappingService)
        {
            mapper = mappingService;
        }

        [NonAction]
        public IActionResult BadRequestWithErrors(params string[] errors)
        {
            return BadRequest(errors);
        }

        [NonAction]
        public IActionResult Identifier(int id)
        {
            return Ok(new Identifier(id));
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ConfigureUserId();
        }

        #region Private methods.

        private void ConfigureUserId()
        {
            if (!User.Identity.IsAuthenticated)
                return;

            string strId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var success = int.TryParse(strId, out int id);

            if (!success)
                throw new InvalidOperationException();

            UserToken.UserId = id;
        }

        #endregion
    }
}