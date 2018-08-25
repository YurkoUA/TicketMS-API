using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketMS.API.Data.Entity
{
    [Table("Summary")]
    public class SummaryEM
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string Tickets { get; set; }
        public string HappyTickets { get; set; }
        public string Packages { get; set; }
    }
}
