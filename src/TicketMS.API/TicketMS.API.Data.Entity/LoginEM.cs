using System;

namespace TicketMS.API.Data.Entity
{
    public class LoginEM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string IpAddress { get; set; }
        public string Browser { get; set; }
        public string UserAgent { get; set; }
        public string Type { get; set; }
        public string Host { get; set; }
    }
}
