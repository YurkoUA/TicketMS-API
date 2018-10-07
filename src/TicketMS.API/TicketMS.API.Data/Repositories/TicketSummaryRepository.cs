using System.Collections.Generic;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Common.Interfaces;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.DTO.Ticket;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class TicketSummaryRepository : DapperRepository, ITicketSummaryRepository
    {
        public TicketSummaryRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<SummaryTicketsDTO> GetSummary(IDateRange dateRange)
        {
            var param = ParametersHelper.CreateFromObject(dateRange);
            return ExecuteSP<SummaryTicketsDTO>("USP_Ticket_Summary", param);
        }

        public IEnumerable<SummaryTicketsDTO> GetSummaryByUnallocated()
        {
            return ExecuteQuery<SummaryTicketsDTO>("SELECT * FROM [v_TicketsUnallocatedSummary]");
        }

        public IEnumerable<SummaryTicketsDTO> GetSummaryByPackage(int packageId)
        {
            var param = ParametersHelper.CreateFromObject(new { packageId });
            return ExecuteSP<SummaryTicketsDTO>("USP_Ticket_SummaryByPackage", param);
        }
    }
}
