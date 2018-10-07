using System.Collections.Generic;
using TicketMS.API.Infrastructure.DTO.Ticket;
using TicketMS.API.ViewModels.Ticket;

namespace TicketMS.API.Infrastructure.Services
{
    public interface ITicketService
    {
        IEnumerable<TicketVM> GetTickets(IPaging paging, out int totalCount);
        IEnumerable<TicketVM> GetTickets(IDateRange dateRange);

        IEnumerable<TicketVM> GetHappyTickets(IPaging paging, out int totalCount);
        IEnumerable<TicketVM> GetUnallocatedTickets();
        IEnumerable<TicketVM> GetReversibleTickets();
        IEnumerable<TicketVM> GetConsistentTickets();
        IEnumerable<TicketVM> GetDuplicatedTickets();

        IEnumerable<TicketVM> GetByPackage(int packageId);
        IEnumerable<TicketVM> GetByNote(string note);
        IEnumerable<TicketVM> GetDuplicatesWith(int id);

        IEnumerable<TicketVM> Filter(TicketFilterDTO filterDTO, IPaging paging, out int totalCount);
        TicketsTotalDTO CountTickets();

        TicketVM GetTicket(int id);
        TicketVM GetRandomTicket();

        int CreateTicket(TicketCreateVM ticket);
        void EditTicket(int id, TicketEditVM ticket);
        void DeleteTicket(int id);

        void ChangeNumber(int id, string number);
        void MoveTicket(int ticketId, int packageId);
        void MoveManyTickets(IEnumerable<int> ticketsIds, int packageId);

        bool NumberExists(string number);
        bool Exists(string number, int colorId, int serialId, string serialNumber);
        bool Exists(string number, int colorId, int serialId, string serialNumber, int id);
    }
}
