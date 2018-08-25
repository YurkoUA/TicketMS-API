using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketMS.API.Data.Entity
{
    [Table("Login")]
    public class LoginEM
    {
        [Key]
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
