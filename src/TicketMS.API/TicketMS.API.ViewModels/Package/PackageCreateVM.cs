using System;
using System.Collections.Generic;
using System.Text;

namespace TicketMS.API.ViewModels.Package
{
    public class PackageCreateVM
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int SerialId { get; set; }
        public int NominalId { get; set; }
        public int? FirstDigit { get; set; }
        public string Note { get; set; }
    }
}
