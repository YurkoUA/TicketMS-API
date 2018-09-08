using System.Collections.Generic;
using System.Linq;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.DTO.Ticket;
using TicketMS.API.Infrastructure.Extensions;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class TicketRepository : DapperRepository, ITicketRepository
    {
        const string SPLIT_ON = "PackageId,SerialId,ColorId,NominalId";
        const string SPLIT_ON_UNALLOCATED = "SerialId,ColorId,NominalId";
        const string SPLIT_ON_SHORT = "Id,Id,Id,Id";

        public TicketRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<TicketEM> GetTickets(IPaging paging, out int totalCount)
        {
            var param = ParametersHelper.CreateFromObject(paging).IncludeOutputTotal();
            var tickets = ExecuteSP<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("USP_Ticket_GetList", 
                TicketEM.MapTicket, SPLIT_ON, param);

            totalCount = param.GetOutputTotal();
            return tickets;
        }

        public IEnumerable<TicketEM> GetTickets(IDateRange dateRange)
        {
            var param = ParametersHelper.CreateFromObject(dateRange);
            return ExecuteSP<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("USP_Ticket_GetBetweenDates", 
                TicketEM.MapTicket, SPLIT_ON, param);
        }

        public IEnumerable<TicketEM> GetHappyTickets(IPaging paging, out int totalCount)
        {
            var param = ParametersHelper.CreateFromObject(paging).IncludeOutputTotal();
            var tickets = ExecuteSP<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("USP_Ticket_GetListHappy", 
                TicketEM.MapTicket, SPLIT_ON, param);

            totalCount = param.GetOutputTotal();
            return tickets;
        }

        public IEnumerable<TicketEM> GetUnallocatedTickets()
        {
            return ExecuteQuery<TicketEM, SerialEM, ColorEM, NominalEM, TicketEM>("SELECT * FROM [v_TicketsUnallocated]", 
                TicketEM.MapTicket, SPLIT_ON_UNALLOCATED);
        }

        public IEnumerable<TicketEM> GetReversibleTickets()
        {
            return ExecuteQuery<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("SELECT * FROM [v_TicketsReversible]", 
                TicketEM.MapTicket, SPLIT_ON);
        }

        public IEnumerable<TicketEM> GetConsistentTickets()
        {
            return ExecuteQuery<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("SELECT * FROM [v_TicketsConsistent]", 
                TicketEM.MapTicket, SPLIT_ON);
        }

        public IEnumerable<TicketEM> GetDuplicatedTickets()
        {
            return ExecuteQuery<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("SELECT * FROM [v_TicketsDuplicates]", 
                TicketEM.MapTicket, SPLIT_ON);
        }

        public IEnumerable<TicketEM> GetByPackage(int packageId)
        {
            var param = ParametersHelper.CreateFromObject(new { packageId });
            return ExecuteSP<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("USP_Ticket_GetByPackage", 
                TicketEM.MapTicket, SPLIT_ON, param);
        }

        public IEnumerable<TicketEM> GetByNote(string note)
        {
            var param = ParametersHelper.CreateFromObject(new { note });
            return ExecuteSP<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("USP_Ticket_GetByNote",
                TicketEM.MapTicket, SPLIT_ON, param);
        }

        public IEnumerable<TicketEM> GetDuplicatesWith(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            return ExecuteSP<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("USP_Ticket_GetDuplicatesWith", 
                TicketEM.MapTicket, SPLIT_ON, param);
        }

        public IEnumerable<TicketEM> Filter(TicketFilterDTO filterDTO, IPaging paging, out int totalCount)
        {
            var param = ParametersHelper.CreateFromObject(filterDTO, paging).IncludeOutputTotal();
            var tickets = ExecuteSP<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("USP_Ticket_Filter", 
                TicketEM.MapTicket, SPLIT_ON, param);

            totalCount = param.GetOutputTotal();
            return tickets;
        }

        public TicketsTotalDTO CountTickets()
        {
            return ExecuteQuerySingle<TicketsTotalDTO>("SELECT * FROM [v_TicketsTotal]");
        }

        public TicketEM GetTicket(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            return ExecuteSP<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("USP_Ticket_Get", TicketEM.MapTicket, SPLIT_ON_SHORT, param)
                .FirstOrDefault();
        }

        public TicketEM GetRandomTicket()
        {
            return ExecuteSP<TicketEM, PackageEM, SerialEM, ColorEM, NominalEM, TicketEM>("USP_Ticket_GetRandom", TicketEM.MapTicket, SPLIT_ON_SHORT)
                .FirstOrDefault();
        }

        public int CreateTicket(TicketCreateDTO ticketDTO)
        {
            var param = ParametersHelper.CreateFromObject(ticketDTO).IncludeOutputId();
            ExecuteSP("USP_Ticket_Create", param);
            return param.GetOutputId();
        }

        public void EditTicket(int id, TicketDTO ticketDTO)
        {
            var param = ParametersHelper.CreateFromObject(ticketDTO).IncludeId(id);
            ExecuteSP("USP_Ticket_Edit", param);
        }

        public void DeleteTicket(int id)
        {
            Delete<TicketEM>(id);
        }

        public void ChangeNumber(int id, string number)
        {
            var param = ParametersHelper.CreateFromObject(new { number }).IncludeId(id);
            ExecuteSP("USP_Ticket_ChangeNumber", param);
        }

        public void MoveTicket(int ticketId, int packageId)
        {
            var param = ParametersHelper.CreateFromObject(new { ticketId, packageId });
            ExecuteSP("USP_Ticket_Move", param);
        }

        public void MoveManyTickets(IEnumerable<int> ticketsIds, int packageId)
        {
            var param = ParametersHelper.CreateFromObject(new { ticketsIds, packageId });
            ExecuteSP("USP_Ticket_MoveMany", param);
        }

        public bool NumberExists(string number)
        {
            var param = ParametersHelper.CreateFromObject(new { number });
            return ExecuteAggregateQuery<bool>("[dbo].[fn_Ticket_NumberExists](@number)", param);
        }

        public bool Exists(string number, int colorId, int serialId, string serialNumber)
        {
            var param = ParametersHelper.CreateFromObject(new { number, colorId, serialId, serialNumber });
            var sql = "SELECT [dbo].[fn_Ticket_Exists](@number, @colorId, @serialId, @serialNumber)";
            return ExecuteAggregateQuery<bool>(sql, param);
        }

        public bool Exists(string number, int colorId, int serialId, string serialNumber, int id)
        {
            var param = ParametersHelper.CreateFromObject(new { number, colorId, serialId, serialNumber }).IncludeId(id);
            var sql = "SELECT [dbo].[fn_Ticket_Exists](@number, @colorId, @serialId, @serialNumber, @id)";
            return ExecuteAggregateQuery<bool>(sql, param);
        }
    }
}
