using Microsoft.AspNetCore.Mvc.ModelBinding;
using TicketMS.API.Infrastructure.Common.Attributes.Validation;

namespace TicketMS.API.ViewModels.Ticket
{
    public class TicketEditVM : TicketCreateVM
    {
        [BindNever]
        public int Id { get; set; }

        [TicketNumber]
        public string Number { get; set; }

        public int? PackageId { get; set; }
    }
}
