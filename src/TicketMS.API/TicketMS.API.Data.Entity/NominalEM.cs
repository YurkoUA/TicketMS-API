namespace TicketMS.API.Data.Entity
{
    public class NominalEM
    {
        public int Id { get; set; }
        public decimal Value { get; set; }

        public bool IsDefault { get; set; }

        public int PackagesCount { get; set; }
        public int TicketsCount { get; set; }
    }
}
