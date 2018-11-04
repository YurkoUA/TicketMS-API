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
        public IActionResult GetAll(PagingVM pagingVM)
        {
            return Ok(ticketService.GetTickets(pagingVM, out _));
        }

        [HttpGet("Dates")]
        public IActionResult GetByDates(DateRangeVM dateRangeVM)
        {
            return Ok(ticketService.GetTickets(dateRangeVM));
        }

        [HttpGet("Happy")]
        public IActionResult GetHappy(PagingVM pagingVM)
        {
            return Ok(ticketService.GetHappyTickets(pagingVM, out _));
        }

        [HttpGet("Unallocated")]
        public IActionResult GetUnallocated()
        {
            return Ok(ticketService.GetUnallocatedTickets());
        }

        [HttpGet("Reversible")]
        public IActionResult GetReversible()
        {
            return Ok(ticketService.GetReversibleTickets());
        }

        [HttpGet("Consistent")]
        public IActionResult GetConsistent()
        {
            return Ok(ticketService.GetConsistentTickets());
        }

        [HttpGet("Duplicated")]
        public IActionResult GetDuplicated()
        {
            return Ok(ticketService.GetDuplicatedTickets());
        }

        [HttpGet("ByPackage/{packageId?}")]
        public IActionResult GetByPackage(int packageId)
        {
            return Ok(ticketService.GetByPackage(packageId));
        }

        [HttpGet("ByNote")]
        public IActionResult GetByNote(SearchVM searchVM)
        {
            return Ok(ticketService.GetByNote(searchVM.Expression));
        }

        [HttpGet("DuplicatesWith/{id?}")]
        public IActionResult GetDuplicatesWith(int id)
        {
            return Ok(ticketService.GetDuplicatesWith(id));
        }

        [HttpGet("Filter")]
        public IActionResult Filter(TicketFilterVM filterVM)
        {
            return Ok(ticketService.Filter(filterVM, out _));
        }

        [HttpGet("Find")]
        public IActionResult Find(TicketSearchVM searchVM)
        {
            return Ok(ticketService.Find(searchVM));
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            return Ok(ticketService.CountTickets());
        }

        [HttpGet("Get/{id?}")]
        public IActionResult GetById(int id)
        {
            return Ok(ticketService.GetTicket(id));
        }

        [HttpGet("Random")]
        public IActionResult GetRandom()
        {
            return Ok(ticketService.GetRandomTicket());
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Create([FromBody]TicketCreateVM ticket)
        {
            var id = ticketService.CreateTicket(ticket);
            return Identifier(id);
        }

        [HttpPut("{id?}")]
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

        [HttpPut("ChangeNumber/{id?}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ChangeNumber(int id, [FromBody]TicketNumberVM numberVM)
        {
            ticketService.ChangeNumber(id, numberVM.Number);
            return Ok();
        }

        [HttpPut("Move/{id?}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Move([FromBody]TicketMoveVM moveVM)
        {
            ticketService.MoveTicket(moveVM);
            return Ok();
        }

        [HttpPut("MoveMany/{id?}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult MoveMany([FromBody]TicketMoveManyVM moveVM)
        {
            ticketService.MoveManyTickets(moveVM);
            return Ok();
        }
    }
}
