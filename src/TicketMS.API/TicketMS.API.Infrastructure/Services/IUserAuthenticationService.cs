using TicketMS.API.Infrastructure.Models.Security;

namespace TicketMS.API.Infrastructure.Services
{
    public interface IUserAuthenticationService
    {
        JsonWebToken Authenticate(string emailOrUserName, string password);
        void ChangePassword(int id, string oldPassword, string newPassword);
    }
}
