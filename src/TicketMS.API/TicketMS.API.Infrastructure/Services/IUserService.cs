using TicketMS.API.Data.Entity;

namespace TicketMS.API.Infrastructure.Services
{
    public interface IUserService
    {
        UserEM FindUser(int id);
        UserEM FindUser(string emailOrUserName);
    }
}
