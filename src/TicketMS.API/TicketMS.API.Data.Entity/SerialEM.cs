namespace TicketMS.API.Data.Entity
{
    public class SerialEM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        public int PackagesCount { get; set; }
        public int TicketsCount { get; set; }
    }
}
