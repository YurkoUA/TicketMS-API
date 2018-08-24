using System;
using System.Collections.Generic;

namespace TicketMS.API.Data.Entity
{
    public class ReportEM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsAutomatic { get; set; }
        public IEnumerable<ReportDocumentEM> Documents { get; set; }
    }
}
