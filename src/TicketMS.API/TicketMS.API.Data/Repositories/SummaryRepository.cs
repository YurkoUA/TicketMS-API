using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class SummaryRepository : DapperRepository, ISummaryRepository
    {
        public SummaryRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<SummaryEM> GetSummary()
        {
            return GetAll<SummaryEM>();
        }

        public void AddSummary()
        {
            ExecuteSP("USP_Summary_Create");
        }
    }
}
