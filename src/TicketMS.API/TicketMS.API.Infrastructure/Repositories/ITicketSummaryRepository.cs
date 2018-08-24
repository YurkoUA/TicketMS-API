using System;
using System.Collections.Generic;
using TicketMS.API.Data.Entity.Secondary;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface ITicketSummaryRepository
    {
        IEnumerable<SummaryTicketsEM> GetSummary(DateTime startDate, DateTime endDate);
        IEnumerable<SummaryTicketsEM> GetSummaryByUnallocated();
        IEnumerable<SummaryTicketsEM> GetSummaryByPackage(int packageId);
    }
}
