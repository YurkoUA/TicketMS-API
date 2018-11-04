using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels;
using TicketMS.API.ViewModels.Ticket;

namespace TicketMS.API.Controllers
{
    public class TicketController : ApplicationController
    {
        private readonly ITicketService ticketService;

        public TicketController(IMappingService mappingService, ITicketService ticketService) : base(mappingService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetAll(PagingVM pagingVM)
        {
            return Ok(ticketService.GetTickets(pagingVM, out _));
        }

        [HttpGet]
        public IActionResult GetByDates(DateRangeVM dateRangeVM)
        {
            return Ok(ticketService.GetTickets(dateRangeVM));
        }

        [HttpGet]
        public IActionResult GetHappy(PagingVM pagingVM)
        {
            return Ok(ticketService.GetHappyTickets(pagingVM, out _));
        }

        [HttpGet]
        public IActionResult GetUnallocated()
        {
            return Ok(ticketService.GetUnallocatedTickets());
        }

        [HttpGet]
        public IActionResult GetReversible()
        {
            return Ok(ticketService.GetReversibleTickets());
        }

        [HttpGet]
        public IActionResult GetConsistent()
        {
            return Ok(ticketService.GetConsistentTickets());
        }

        [HttpGet]
        public IActionResult GetDuplicated()
        {
            return Ok(ticketService.GetDuplicatedTickets());
        }

        [HttpGet]
        public IActionResult GetByPackage(int packageId)
        {
            return Ok(ticketService.GetByPackage(packageId));
        }

        [HttpGet]
        public IActionResult GetByNote(SearchVM searchVM)
        {
            return Ok(ticketService.GetByNote(searchVM.Expression));
        }

        [HttpGet]
        public IActionResult GetDuplicatesWith(int id)
        {
            return Ok(ticketService.GetDuplicatesWith(id));
        }

        [HttpGet]
        public IActionResult Filter(TicketFilterVM filterVM)
        {
            return Ok(ticketService.Filter(filterVM, out _));
        }

        [HttpGet]
        public IActionResult Find(TicketSearchVM searchVM)
        {
            return Ok(ticketService.Find(searchVM));
        }

        [HttpGet]
        public IActionResult Count()
        {
            return Ok(ticketService.CountTickets());
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(ticketService.GetTicket(id));
        }

        [HttpGet]
        public IActionResult GetRandom()
        {
            return Ok(ticketService.GetRandomTicket());
        }

        [HttpGet]
        public IActionResult GetTicket(int id)
        {
            return Ok(ticketService.GetTicket(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody]TicketCreateVM ticket)
        {
            var id = ticketService.CreateTicket(ticket);
            return Identifier(id);
        }

        [HttpPut]
        public IActionResult Edit(int id, [FromBody]TicketEditVM ticket)
        {
            ticketService.EditTicket(id, ticket);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ticketService.DeleteTicket(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult ChangeNumber(int id, [FromBody]TicketNumberVM numberVM)
        {
            ticketService.ChangeNumber(id, numberVM.Number);
            return Ok();
        }

        [HttpPut]
        public IActionResult Move([FromBody]TicketMoveVM moveVM)
        {
            ticketService.MoveTicket(moveVM);
            return Ok();
        }

        [HttpPut]
        public IActionResult MoveMany([FromBody]TicketMoveManyVM moveVM)
        {
            ticketService.MoveManyTickets(moveVM);
            return Ok();
        }
    }
}
