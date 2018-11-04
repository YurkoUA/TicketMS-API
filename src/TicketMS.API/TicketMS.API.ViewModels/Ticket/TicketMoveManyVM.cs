using System.Collections.Generic;

namespace TicketMS.API.ViewModels.Ticket
{
    public class TicketMoveManyVM
    {
        public IEnumerable<int> TicketsIds { get; set; }
        public int PackageId { get; set; }
    }
}
