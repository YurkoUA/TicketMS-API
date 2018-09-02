using TicketMS.API.ViewModels.User;

namespace TicketMS.API.Infrastructure.Services
{
    public interface IUserService
    {
        UserVM FindUser(int id);
        UserVM FindUser(string emailOrUserName);
    }
}
