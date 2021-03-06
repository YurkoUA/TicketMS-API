﻿using System.Collections.Generic;
using TicketMS.API.Infrastructure.Common.Interfaces;
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

        IEnumerable<TicketVM> Filter(TicketFilterVM filterVM, out int totalCount);
        IEnumerable<TicketVM> Find(TicketSearchVM searchVM);
        TicketsTotalDTO CountTickets();

        TicketVM GetTicket(int id);
        TicketVM GetRandomTicket();

        int CreateTicket(TicketCreateVM ticket);
        void EditTicket(int id, TicketEditVM ticket);
        void DeleteTicket(int id);

        void ChangeNumber(int id, string number);
        void MoveTicket(TicketMoveVM ticketMoveVM);
        void MoveManyTickets(TicketMoveManyVM ticketMoveVM);

        bool NumberExists(string number);
        bool Exists(string number, int colorId, int serialId, string serialNumber);
        bool Exists(string number, int colorId, int serialId, string serialNumber, int id);
    }
}
