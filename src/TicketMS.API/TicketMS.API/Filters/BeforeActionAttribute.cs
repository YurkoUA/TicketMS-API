using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using TicketMS.API.Infrastructure.Annotations;

namespace TicketMS.API.Filters
{
    public class BeforeActionAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action.
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments.Where(arg => arg.Value is IBeforeAction)
                .Select(arg => arg.Value as IBeforeAction)
                .ToList()
                .ForEach(p => p.ExecuteBeforeAction(context));
        }
    }
}
