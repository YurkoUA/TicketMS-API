using System;
using System.Collections.Generic;
using System.Text;

namespace TicketMS.API.ViewModels.Ticket
{
    public class TicketCreateVM
    {
        public int NominalId { get; set; }
        public int ColorId { get; set; }
        public int SerialId { get; set; }
        public string SerialNumber { get; set; }
        public string Note { get; set; }
        public string Date { get; set; }
    }
}
