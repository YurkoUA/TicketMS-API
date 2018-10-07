using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Common.Interfaces;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class LoginRepository : DapperRepository, ILoginRepository
    {
        public LoginRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<LoginEM> GetLogins(int userId, IPaging paging)
        {
            var param = ParametersHelper.CreateFromObject(paging, new { userId });
            return ExecuteSP<LoginEM>("USP_Login_GetList", param);
        }

        public void AddLogin(LoginEM login)
        {
            Insert(login);
        }
    }
}
