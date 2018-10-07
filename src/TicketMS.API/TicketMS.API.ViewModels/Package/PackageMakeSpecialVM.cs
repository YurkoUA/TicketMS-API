using System;
using System.Collections.Generic;
using System.Text;

namespace TicketMS.API.ViewModels.Package
{
    public class PackageMakeSpecialVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ResetColor { get; set; }
        public bool ResetSerial { get; set; }
    }
}
