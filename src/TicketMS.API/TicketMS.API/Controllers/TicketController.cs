using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("List")]
        public IActionResult GetAll([FromQuery]PagingVM pagingVM)
        {
            var tickets = ticketService.GetTickets(pagingVM, out int totalCount);
            return PagingResponse(tickets, totalCount);
        }

        [HttpGet("Dates")]
        public IActionResult GetByDates([FromQuery]DateRangeVM dateRangeVM)
        {
            var tickets = ticketService.GetTickets(dateRangeVM);
            return Ok(tickets);
        }

        [HttpGet("Happy")]
        public IActionResult GetHappy([FromQuery]PagingVM pagingVM)
        {
            var tickets = ticketService.GetHappyTickets(pagingVM, out int total);
            return PagingResponse(tickets, total);
        }

        [HttpGet("Unallocated")]
        public IActionResult GetUnallocated()
        {
            var tickets = ticketService.GetUnallocatedTickets();
            return Ok(tickets);
        }

        [HttpGet("Reversible")]
        public IActionResult GetReversible()
        {
            var tickets = ticketService.GetReversibleTickets();
            return Ok(tickets);
        }

        [HttpGet("Consistent")]
        public IActionResult GetConsistent()
        {
            var tickets = ticketService.GetConsistentTickets();
            return Ok(tickets);
        }

        [HttpGet("Duplicated")]
        public IActionResult GetDuplicated()
        {
            var tickets = ticketService.GetDuplicatedTickets();
            return Ok(tickets);
        }

        [HttpGet("ByPackage")]
        public IActionResult GetByPackage(int packageId)
        {
            var tickets = ticketService.GetByPackage(packageId);
            return Ok(tickets);
        }

        [HttpGet("ByNote")]
        public IActionResult GetByNote([FromQuery]SearchVM searchVM)
        {
            var tickets = ticketService.GetByNote(searchVM.Expression);
            return Ok(tickets);
        }

        [HttpGet("DuplicatesWith")]
        public IActionResult GetDuplicatesWith(int id)
        {
            var tickets = ticketService.GetDuplicatesWith(id);
            return Ok(tickets);
        }

        [HttpGet("Filter")]
        public IActionResult Filter([FromQuery]TicketFilterVM filterVM)
        {
            var tickets = ticketService.Filter(filterVM, out int total);
            return PagingResponse(tickets, total);
        }

        [HttpGet("Find")]
        public IActionResult Find([FromQuery]TicketSearchVM searchVM)
        {
            var tickets = ticketService.Find(searchVM);
            return Ok(tickets);
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            var count = ticketService.CountTickets();
            return Ok(count);
        }

        [HttpGet("Get")]
        public IActionResult GetById(int id)
        {
            var ticket = ticketService.GetTicket(id);
            return Ok();
        }

        [HttpGet("Random")]
        public IActionResult GetRandom()
        {
            var ticket = ticketService.GetRandomTicket();
            return Ok(ticket);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Create([FromBody]TicketCreateVM ticket)
        {
            var id = ticketService.CreateTicket(ticket);
            return Identifier(id);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Edit(int id, [FromBody]TicketEditVM ticket)
        {
            ticketService.EditTicket(id, ticket);
            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete(int id)
        {
            ticketService.DeleteTicket(id);
            return Ok();
        }

        [HttpPut("ChangeNumber")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ChangeNumber(int id, [FromBody]TicketNumberVM numberVM)
        {
            ticketService.ChangeNumber(id, numberVM.Number);
            return Ok();
        }

        [HttpPut("Move")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Move([FromBody]TicketMoveVM moveVM)
        {
            ticketService.MoveTicket(moveVM);
            return Ok();
        }

        [HttpPut("MoveMany")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult MoveMany([FromBody]TicketMoveManyVM moveVM)
        {
            ticketService.MoveManyTickets(moveVM);
            return Ok();
        }
    }
}
