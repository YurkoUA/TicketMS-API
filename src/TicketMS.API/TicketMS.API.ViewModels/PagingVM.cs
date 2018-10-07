using TicketMS.API.Infrastructure.Common.Interfaces;

namespace TicketMS.API.ViewModels
{
    public class PagingVM : IPaging
    {
        public int Offset { get; set; }
        public int Take { get; set; }
    }
}
