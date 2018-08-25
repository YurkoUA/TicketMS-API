using System;
using System.Collections.Generic;
using TicketMS.API.Data.Entity.Secondary;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class TicketSummaryRepository : DapperRepository, ITicketSummaryRepository
    {
        public TicketSummaryRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<SummaryTicketsEM> GetSummary(DateTime startDate, DateTime endDate)
        {
            var param = ParametersHelper.CreateFromObject(new { startDate, endDate });
            return ExecuteSP<SummaryTicketsEM>("USP_Ticket_Summary", param);
        }

        public IEnumerable<SummaryTicketsEM> GetSummaryByUnallocated()
        {
            return ExecuteQuery<SummaryTicketsEM>("SELECT * FROM [v_TicketsUnallocatedSummary]");
        }

        public IEnumerable<SummaryTicketsEM> GetSummaryByPackage(int packageId)
        {
            var param = ParametersHelper.CreateFromObject(new { packageId });
            return ExecuteSP<SummaryTicketsEM>("USP_Ticket_SummaryByPackage", param);
        }
    }
}
