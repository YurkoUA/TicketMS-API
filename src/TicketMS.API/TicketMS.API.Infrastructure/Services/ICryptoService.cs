namespace TicketMS.API.Infrastructure.Services
{
    public interface ICryptoService
    {
        byte[] GenerateRandomBytes(int length);
        byte[] ComputeHash(byte[] bytes);
        byte[] Xor(params byte[][] bytes);
    }
}
