using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using TicketMS.API.Infrastructure.Exceptions;

namespace TicketMS.API.Filters
{
    public class HandleExceptionAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled)
                return;

            int statusCode = 500;

            if (context.Exception is CustomException)
            {
                statusCode = (int)(context.Exception as CustomException).StatusCode;
            }

            context.ExceptionHandled = true;

            context.HttpContext.Response.StatusCode = 500;
            context.HttpContext.Response.Headers.Add("Content-Type", new StringValues("application/json"));
            context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { context.Exception.Message }));
        }
    }
}
