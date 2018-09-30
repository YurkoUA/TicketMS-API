using System;
using TicketMS.API.ViewModels.Color;
using TicketMS.API.ViewModels.Nominal;
using TicketMS.API.ViewModels.Package;
using TicketMS.API.ViewModels.Serial;

namespace TicketMS.API.ViewModels.Ticket
{
    public class TicketVM
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public PackageSimpleVM Package { get; set; }
        public NominalSimpleVM Nominal { get; set; }
        public ColorSimpleVM Color { get; set; }

        public SerialSimpleVM Serial { get; set; }
        public string SerialNumber { get; set; }

        public string Date { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool IsHappy { get; set; }
        public int? DuplicatesCount { get; set; }
    }
}
