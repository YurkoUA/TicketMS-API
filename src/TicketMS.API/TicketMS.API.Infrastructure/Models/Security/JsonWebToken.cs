using System;

namespace TicketMS.API.Infrastructure.Models.Security
{
    public class JsonWebToken
    {
        public string Token { get; set; }
        public DateTime ExpiresDate { get; set; }
    }
}
