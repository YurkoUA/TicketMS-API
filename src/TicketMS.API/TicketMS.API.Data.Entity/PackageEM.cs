using System;

namespace TicketMS.API.Data.Entity
{
    public class PackageEM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FirstDigit { get; set; }

        public NominalEM Nominal { get; set; }
        public ColorEM Color { get; set; }
        public SerialEM Serial { get; set; }

        public bool IsOpened { get; set; }
        public bool IsSpecial { get; set; }

        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }

        public int TicketsCount { get; set; }
        public int? UnallocatedToMoveCount { get; set; }

        public static PackageEM MapPackage(PackageEM package, SerialEM serial, ColorEM color, NominalEM nominal)
        {
            package.Serial = serial;
            package.Color = color;
            package.Nominal = nominal;
            return package;
        }
    }
}
