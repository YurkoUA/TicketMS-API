using System;
using System.Collections.Generic;
using System.Text;

namespace TicketMS.API.ViewModels.Ticket
{
    public class TicketEditVM : TicketCreateVM
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int? PackageId { get; set; }
    }
}
