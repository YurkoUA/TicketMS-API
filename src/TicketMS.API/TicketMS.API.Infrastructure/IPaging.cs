namespace TicketMS.API.Infrastructure
{
    public interface IPaging
    {
        int Offset { get; set; }
        int Take { get; set; }
    }
}
