namespace TicketMS.API.Infrastructure.DTO
{
    public abstract class FilterDTO
    {
        public int FirstDigit { get; set; }
        public int NominalId { get; set; }
        public int ColorId { get; set; }
        public int SerialId { get; set; }
    }
}
