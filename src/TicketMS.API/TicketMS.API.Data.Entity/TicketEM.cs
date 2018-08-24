using System;

namespace TicketMS.API.Data.Entity
{
    public class TicketEM
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public PackageEM Package { get; set; }
        public NominalEM Nominal { get; set; }
        public ColorEM Color { get; set; }

        public SerialEM Serial { get; set; }
        public string SerialNumber { get; set; }

        public string Date { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool IsHappy { get; set; }
        public int? DuplicatesCount { get; set; }
    }
}
