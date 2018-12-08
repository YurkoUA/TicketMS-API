using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Exceptions;
using TicketMS.API.Infrastructure.Helpers;

namespace TicketMS.API.Filters
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
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
            else if (context.Exception is SqlException sqlExp && sqlExp.Number >= Constants.SQL_CUSTOM_EXCEPTION_STARTS)
            {
                statusCode = 400;
            }

            context.ExceptionHandled = true;

            context.HttpContext.Response.StatusCode = statusCode;
            context.HttpContext.Response.Headers.Add(Constants.CONTENT_TYPE, new StringValues(Constants.JSON_MIME));
            context.HttpContext.Response.WriteAsync(JsonHelper.SerializeAsArray(context.Exception.Message));
        }
    }
}
