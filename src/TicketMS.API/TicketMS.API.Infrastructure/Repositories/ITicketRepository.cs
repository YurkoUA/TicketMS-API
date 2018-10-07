using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.Common.Interfaces;
using TicketMS.API.Infrastructure.DTO.Ticket;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface ITicketRepository : IRepository
    {
        IEnumerable<TicketEM> GetTickets(IPaging paging, out int totalCount);
        IEnumerable<TicketEM> GetTickets(IDateRange dateRange);

        IEnumerable<TicketEM> GetHappyTickets(IPaging paging, out int totalCount);
        IEnumerable<TicketEM> GetUnallocatedTickets();
        IEnumerable<TicketEM> GetReversibleTickets();
        IEnumerable<TicketEM> GetConsistentTickets();
        IEnumerable<TicketEM> GetDuplicatedTickets();

        IEnumerable<TicketEM> GetByPackage(int packageId);
        IEnumerable<TicketEM> GetByNote(string note);
        IEnumerable<TicketEM> GetDuplicatesWith(int id);

        IEnumerable<TicketEM> Filter(TicketFilterDTO filterDTO, IPaging paging, out int totalCount);
        TicketsTotalDTO CountTickets();

        TicketEM GetTicket(int id);
        TicketEM GetRandomTicket();

        int CreateTicket(TicketCreateDTO ticketDTO);
        void EditTicket(int id, TicketDTO ticketDTO);
        void DeleteTicket(int id);

        void ChangeNumber(int id, string number);
        void MoveTicket(int ticketId, int packageId);
        void MoveManyTickets(IEnumerable<int> ticketsIds, int packageId);

        bool NumberExists(string number);
        bool Exists(string number, int colorId, int serialId, string serialNumber);
        bool Exists(string number, int colorId, int serialId, string serialNumber, int id);
    }
}
