using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TicketMS.API.Extensions
{
    public static class ValidationExtensions
    {
        public static IEnumerable<string> ToEnumerableString(this ModelStateDictionary modelState)
        {
            return modelState.Values.Where(e => e.Errors.Any())
                    .SelectMany(e => e.Errors)
                    .Select(e => e.ErrorMessage);
        }
    }
}
