namespace TicketMS.API.Data.Entity
{
    public class ColorEM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PaletteName { get; set; }
        
        public int PackagesCount { get; set; }
        public int TicketsCount { get; set; }
    }
}
