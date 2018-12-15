using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TicketMS.API.Filters;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Models;
using TicketMS.API.ViewModels;
using TicketMS.API.ViewModels.Primitives;

namespace TicketMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [HandleException]
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

        [NonAction]
        public IActionResult PagingResponse<TItem>(IEnumerable<TItem> items, int totalCount)
        {
            return Ok(new PagingResponseVM<TItem>
            {
                Items = items,
                TotalCount = totalCount
            });
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