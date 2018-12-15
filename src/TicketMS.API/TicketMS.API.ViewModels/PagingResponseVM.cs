using System.Collections.Generic;

namespace TicketMS.API.ViewModels
{
    public class PagingResponseVM<TItem>
    {
        public int TotalCount { get; set; }
        public IEnumerable<TItem> Items { get; set; }
    }
}
