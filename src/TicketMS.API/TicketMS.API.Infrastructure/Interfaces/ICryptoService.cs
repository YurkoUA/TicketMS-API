namespace TicketMS.API.Infrastructure.Interfaces
{
    public interface ICryptoService
    {
        byte[] GenerateSalt(int length);
        byte[] ComputeHash(byte[] bytes);
        byte[] Xor(params byte[][] bytes);
    }
}
