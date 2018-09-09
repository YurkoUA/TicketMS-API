using TicketMS.API.Infrastructure.Common.Models.Security;
using TicketMS.API.ViewModels.User;

namespace TicketMS.API.Infrastructure.Services
{
    public interface IUserAuthenticationService
    {
        JsonWebToken Authenticate(string emailOrUserName, string password, out UserVM user);
        void ChangePassword(int id, string currentPassword, string newPassword);
    }
}
