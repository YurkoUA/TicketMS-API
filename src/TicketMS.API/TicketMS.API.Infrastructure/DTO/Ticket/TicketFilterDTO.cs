namespace TicketMS.API.Infrastructure.DTO.Ticket
{
    public class TicketFilterDTO : FilterDTO
    {
        public bool OnlyUnallocated { get; set; }
    }
}
