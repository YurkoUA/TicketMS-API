using System.Collections.Generic;
using TicketMS.API.Infrastructure.Common.Interfaces;
using TicketMS.API.ViewModels.User;

namespace TicketMS.API.Infrastructure.Services
{
    public interface ILoginService
    {
        IEnumerable<LoginVM> GetLogins(int userId, IPaging paging);
        void AddLogin(LoginVM login);
    }
}
