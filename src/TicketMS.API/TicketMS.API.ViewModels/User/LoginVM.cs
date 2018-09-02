using System;

namespace TicketMS.API.ViewModels.User
{
    public class LoginVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public string IpAddress { get; set; }
        public string Browser { get; set; }
        public string UserAgent { get; set; }
        public string Type { get; set; }
        public string Host { get; set; }
    }
}
