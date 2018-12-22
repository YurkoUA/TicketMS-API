using System.ComponentModel.DataAnnotations;
using TicketMS.API.Infrastructure.Common.Attributes.Validation;

namespace TicketMS.API.ViewModels.Ticket
{
    public class TicketCreateVM
    {
        public int NominalId { get; set; }
        public int ColorId { get; set; }
        public int SerialId { get; set; }

        [SerialNumber]
        public string SerialNumber { get; set; }

        [StringLength(128)]
        public string Note { get; set; }

        [StringLength(32)]
        public string Date { get; set; }
    }
}
