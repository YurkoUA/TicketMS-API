using System.Collections.Generic;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Common.Interfaces;
using TicketMS.API.Infrastructure.DTO.Ticket;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Repositories;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels.Ticket;

namespace TicketMS.API.Business.Services
{
    public class TicketService : Service, ITicketService
    {
        private readonly ITicketRepository ticketRepository;

        public TicketService(IMappingService mapper, ITicketRepository ticketRepository) : base(mapper)
        {
            this.ticketRepository = ticketRepository;
        }

        public IEnumerable<TicketVM> GetTickets(IPaging paging, out int totalCount)
        {
            var tickets = ticketRepository.GetTickets(paging, out totalCount);
            return mapper.ConvertCollectionTo<TicketVM>(tickets);
        }

        public IEnumerable<TicketVM> GetTickets(IDateRange dateRange)
        {
            var tickets = ticketRepository.GetTickets(dateRange);
            return mapper.ConvertCollectionTo<TicketVM>(tickets);
        }

        public IEnumerable<TicketVM> GetHappyTickets(IPaging paging, out int totalCount)
        {
            var tickets = ticketRepository.GetHappyTickets(paging, out totalCount);
            return mapper.ConvertCollectionTo<TicketVM>(tickets);
        }

        public IEnumerable<TicketVM> GetUnallocatedTickets()
        {
            var tickets = ticketRepository.GetUnallocatedTickets();
            return mapper.ConvertCollectionTo<TicketVM>(tickets);
        }

        public IEnumerable<TicketVM> GetReversibleTickets()
        {
            var tickets = ticketRepository.GetReversibleTickets();
            return mapper.ConvertCollectionTo<TicketVM>(tickets);
        }

        public IEnumerable<TicketVM> GetConsistentTickets()
        {
            var tickets = ticketRepository.GetConsistentTickets();
            return mapper.ConvertCollectionTo<TicketVM>(tickets);
        }

        public IEnumerable<TicketVM> GetDuplicatedTickets()
        {
            var tickets = ticketRepository.GetDuplicatedTickets();
            return mapper.ConvertCollectionTo<TicketVM>(tickets);
        }

        public IEnumerable<TicketVM> GetByPackage(int packageId)
        {
            var tickets = ticketRepository.GetByPackage(packageId);
            return mapper.ConvertCollectionTo<TicketVM>(tickets);
        }

        public IEnumerable<TicketVM> GetByNote(string note)
        {
            var tickets = ticketRepository.GetByNote(note);
            return mapper.ConvertCollectionTo<TicketVM>(tickets);
        }

        public IEnumerable<TicketVM> GetDuplicatesWith(int id)
        {
            var tickets = ticketRepository.GetDuplicatesWith(id);
            return mapper.ConvertCollectionTo<TicketVM>(tickets);
        }

        public IEnumerable<TicketVM> Filter(TicketFilterDTO filterDTO, IPaging paging, out int totalCount)
        {
            var tickets = ticketRepository.Filter(filterDTO, paging, out totalCount);
            return mapper.ConvertCollectionTo<TicketVM>(tickets);
        }

        public TicketsTotalDTO CountTickets()
        {
            return ticketRepository.CountTickets();
        }

        public TicketVM GetTicket(int id)
        {
            var ticket = ticketRepository.GetTicket(id);
            return mapper.ConvertTo<TicketVM>(ticket);
        }

        public TicketVM GetRandomTicket()
        {
            return mapper.ConvertTo<TicketVM>(ticketRepository.GetRandomTicket());
        }

        public int CreateTicket(TicketCreateVM ticket)
        {
            var dto = mapper.ConvertTo<TicketCreateDTO>(ticket);
            return ticketRepository.CreateTicket(dto);
        }

        public void EditTicket(int id, TicketEditVM ticket)
        {
            var dto = mapper.ConvertTo<TicketDTO>(ticket);
            ticketRepository.EditTicket(id, dto);
        }

        public void DeleteTicket(int id)
        {
            ticketRepository.DeleteTicket(id);
        }

        public void ChangeNumber(int id, string number)
        {
            ticketRepository.ChangeNumber(id, number);
        }

        public void MoveTicket(int ticketId, int packageId)
        {
            ticketRepository.MoveTicket(ticketId, packageId);
        }

        public void MoveManyTickets(IEnumerable<int> ticketsIds, int packageId)
        {
            ticketRepository.MoveManyTickets(ticketsIds, packageId);
        }

        public bool NumberExists(string number)
        {
            return ticketRepository.NumberExists(number);
        }

        public bool Exists(string number, int colorId, int serialId, string serialNumber)
        {
            return ticketRepository.Exists(number, colorId, serialId, serialNumber);
        }

        public bool Exists(string number, int colorId, int serialId, string serialNumber, int id)
        {
            return ticketRepository.Exists(number, colorId, serialId, serialNumber, id);
        }
    }
}
