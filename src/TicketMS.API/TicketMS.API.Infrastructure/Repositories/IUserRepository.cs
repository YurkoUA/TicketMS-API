using TicketMS.API.Data.Entity;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository
    {
        UserEM GetUser(int id);
        UserEM FindUser(string emailOrUserName);
        void ChangePassword(int id, byte[] passwordHash, byte[] salt);
    }
}
