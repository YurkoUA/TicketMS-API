namespace TicketMS.API.Infrastructure.DTO.Ticket
{
    public class TicketFilterDTO : FilterDTO, IPaging
    {
        public bool OnlyUnallocated { get; set; }
        public int Offset { get; set; }
        public int Take { get; set; }
    }
}
