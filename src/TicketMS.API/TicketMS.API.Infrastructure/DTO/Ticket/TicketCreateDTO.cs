namespace TicketMS.API.Infrastructure.DTO.Ticket
{
    public class TicketCreateDTO : TicketDTO
    {
        public int Number { get; set; }
        public int? PackageId { get; set; }
    }
}
