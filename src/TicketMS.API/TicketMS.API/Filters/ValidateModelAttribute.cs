using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using TicketMS.API.Controllers;
using TicketMS.API.Extensions;

namespace TicketMS.API.Filters
{
    public class ValidateModelAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action.
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState?.IsValid == false)
            {
                var errors = context.ModelState.ToEnumerableString().ToArray();
                context.Result = (context.Controller as ApplicationController).BadRequestWithErrors(errors);
            }
        }
    }
}
