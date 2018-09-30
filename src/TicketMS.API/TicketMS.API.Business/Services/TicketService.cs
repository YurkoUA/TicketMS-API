using System;
using System.Collections.Generic;
using System.Text;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.DTO.Ticket;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels.Ticket;

namespace TicketMS.API.Business.Services
{
    public class TicketService : Service, ITicketService
    {
        public TicketService(IMappingService mapper) : base(mapper)
        {
        }

        public IEnumerable<TicketVM> GetTickets(IPaging paging, out int totalCount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketVM> GetTickets(IDateRange dateRange)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketVM> GetHappyTickets(IPaging paging, out int totalCount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketVM> GetUnallocatedTickets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketVM> GetReversibleTickets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketVM> GetConsistentTickets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketVM> GetDuplicatedTickets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketVM> GetByPackage(int packageId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketVM> GetByNote(string note)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketVM> GetDuplicatesWith(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketVM> Filter(TicketFilterDTO filterDTO, IPaging paging, out int totalCount)
        {
            throw new NotImplementedException();
        }

        public TicketsTotalDTO CountTickets()
        {
            throw new NotImplementedException();
        }

        public TicketVM GetTicket(int id)
        {
            throw new NotImplementedException();
        }

        public TicketVM GetRandomTicket()
        {
            throw new NotImplementedException();
        }

        public int CreateTicket(TicketCreateDTO ticketDTO)
        {
            throw new NotImplementedException();
        }

        public void EditTicket(int id, TicketDTO ticketDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteTicket(int id)
        {
            throw new NotImplementedException();
        }

        public void ChangeNumber(int id, string number)
        {
            throw new NotImplementedException();
        }

        public void MoveTicket(int ticketId, int packageId)
        {
            throw new NotImplementedException();
        }

        public void MoveManyTickets(IEnumerable<int> ticketsIds, int packageId)
        {
            throw new NotImplementedException();
        }

        public bool NumberExists(string number)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string number, int colorId, int serialId, string serialNumber)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string number, int colorId, int serialId, string serialNumber, int id)
        {
            throw new NotImplementedException();
        }
    }
}
