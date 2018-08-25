using System.Collections.Generic;
using TicketMS.API.Data.Entity;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface ILoginRepository
    {
        IEnumerable<LoginEM> GetLogins(int userId, IPaging paging);
        void AddLogin(LoginEM login);
    }
}
