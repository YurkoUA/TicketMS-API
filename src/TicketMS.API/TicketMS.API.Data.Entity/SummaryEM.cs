using System;

namespace TicketMS.API.Data.Entity
{
    public class SummaryEM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string Tickets { get; set; }
        public string HappyTickets { get; set; }
        public string Packages { get; set; }
    }
}
