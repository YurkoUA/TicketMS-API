using System.Collections.Generic;
using TicketMS.API.Infrastructure.Common.Interfaces;
using TicketMS.API.Infrastructure.DTO.Ticket;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface ITicketSummaryRepository
    {
        IEnumerable<SummaryTicketsDTO> GetSummary(IDateRange dateRange);
        IEnumerable<SummaryTicketsDTO> GetSummaryByUnallocated();
        IEnumerable<SummaryTicketsDTO> GetSummaryByPackage(int packageId);
    }
}
