using System;
using TicketMS.API.ViewModels.Color;
using TicketMS.API.ViewModels.Nominal;
using TicketMS.API.ViewModels.Serial;

namespace TicketMS.API.ViewModels.Package
{
    public class PackageVM : PackageSimpleVM
    {
        public int? FirstDigit { get; set; }

        public NominalSimpleVM Nominal { get; set; }
        public ColorSimpleVM Color { get; set; }
        public SerialSimpleVM Serial { get; set; }

        public bool IsOpened { get; set; }
        public bool IsSpecial { get; set; }

        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }

        public int TicketsCount { get; set; }
        public int? UnallocatedToMoveCount { get; set; }
    }
}
