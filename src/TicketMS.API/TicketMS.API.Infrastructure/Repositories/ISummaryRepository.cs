using System.Collections.Generic;
using TicketMS.API.Data.Entity;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface ISummaryRepository
    {
        IEnumerable<SummaryEM> GetSummary();
        void AddSummary();
    }
}
