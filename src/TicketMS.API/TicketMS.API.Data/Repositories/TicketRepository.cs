using System;
using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Data.Entity.Secondary;
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
        public TicketRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<TicketEM> GetTickets(IPaging paging)
        {
            var param = ParametersHelper.CreateFromObject(paging);
            return ExecuteSP<TicketEM>("USP_Ticket_GetList", param);
        }

        public IEnumerable<TicketEM> GetTickets(DateTime startDate, DateTime endDate)
        {
            var param = ParametersHelper.CreateFromObject(new { startDate, endDate });
            return ExecuteSP<TicketEM>("USP_Ticket_GetBetweenDates", param);
        }

        public IEnumerable<TicketEM> GetHappyTickets(IPaging paging)
        {
            var param = ParametersHelper.CreateFromObject(paging);
            return ExecuteSP<TicketEM>("USP_Ticket_GetListHappy", param);
        }

        public IEnumerable<TicketEM> GetUnallocatedTickets()
        {
            return ExecuteQuery<TicketEM>("SELECT * FROM [v_TicketsUnallocated]");
        }

        public IEnumerable<TicketEM> GetReversibleTickets()
        {
            return ExecuteQuery<TicketEM>("SELECT * FROM [v_TicketsReversible]");
        }

        public IEnumerable<TicketEM> GetConsistentTickets()
        {
            return ExecuteQuery<TicketEM>("SELECT * FROM [v_TicketsConsistent]");
        }

        public IEnumerable<TicketEM> GetDuplicatedTickets()
        {
            return ExecuteQuery<TicketEM>("SELECT * FROM [v_TicketsDuplicates]");
        }

        public IEnumerable<TicketEM> GetByPackage(int packageId)
        {
            var param = ParametersHelper.CreateFromObject(new { packageId });
            return ExecuteSP<TicketEM>("USP_Ticket_GetByPackage", param);
        }

        public IEnumerable<TicketEM> GetDuplicatesWith(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            return ExecuteSP<TicketEM>("USP_Ticket_GetDuplicatesWith", param);
        }

        public IEnumerable<TicketEM> Filter(TicketFilterDTO filterDTO, IPaging paging)
        {
            var param = ParametersHelper.CreateFromObject(filterDTO, paging);
            return ExecuteSP<TicketEM>("USP_Ticket_Filter", param);
        }

        public TicketsTotalEM CountTickets()
        {
            return ExecuteQuerySingle<TicketsTotalEM>("SELECT * FROM [v_TicketsTotal]");
        }

        public int CountTickets(TicketFilterDTO filterDTO)
        {
            var param = ParametersHelper.CreateFromObject(filterDTO);
            var sql = "SELECT [dbo].[fn_Ticket_FilterCount](@firstDigit, @serialId, @colorId, @nominalId, @onlyUnallocated)";
            return ExecuteAggregateQuery<int>(sql, param);
        }

        public TicketEM GetTicket(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            return ExecuteSPSingle<TicketEM>("USP_Ticket_Get", param);
        }

        public TicketEM GetRandomTicket()
        {
            return ExecuteSPSingle<TicketEM>("USP_Ticket_GetRandom");
        }

        public int CreateTicket(TicketDTO ticketDTO)
        {
            var param = ParametersHelper.CreateFromObject(ticketDTO).IncludeReturnedId();
            ExecuteSP("USP_Ticket_Create", param);
            return param.GetReturnedId();
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
