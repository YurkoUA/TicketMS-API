namespace TicketMS.API.Infrastructure.Common.Interfaces
{
    public interface IPaging
    {
        int Offset { get; set; }
        int Take { get; set; }
    }
}
