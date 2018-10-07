using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Services;

namespace TicketMS.API.Controllers
{
    public class TicketController : ApplicationController
    {
        private readonly ITicketService ticketService;

        public TicketController(IMappingService mappingService, ITicketService ticketService) : base(mappingService)
        {
            this.ticketService = ticketService;
        }
    }
}
