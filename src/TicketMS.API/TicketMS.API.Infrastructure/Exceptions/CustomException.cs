using System;
using System.Net;

namespace TicketMS.API.Infrastructure.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.BadRequest;
    }
}
