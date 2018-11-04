using TicketMS.API.Infrastructure.Common.Interfaces;

namespace TicketMS.API.ViewModels.Ticket
{
    public class TicketFilterVM : FilterVM, IPaging
    {
        public bool OnlyUnallocated { get; set; }
        public int Offset { get; set; }
        public int Take { get; set; }
    }
}
