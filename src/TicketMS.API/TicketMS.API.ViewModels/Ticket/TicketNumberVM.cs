using TicketMS.API.Infrastructure.Common.Attributes.Validation;

namespace TicketMS.API.ViewModels.Ticket
{
    public class TicketNumberVM
    {
        [TicketNumber]
        public string Number { get; set; }
    }
}
