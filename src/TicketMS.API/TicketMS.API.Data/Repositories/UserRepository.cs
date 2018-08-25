using System.Linq;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.Extensions;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class UserRepository : DapperRepository, IUserRepository
    {
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public UserEM GetUser(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            return ExecuteSP<UserEM, RoleEM, UserEM>("USP_User_Get", UserEM.MapUser, "Id", param).FirstOrDefault();
        }

        public UserEM FindUser(string emailOrUserName)
        {
            var param = ParametersHelper.CreateFromObject(new { emailOrUserName });
            return ExecuteSP<UserEM, RoleEM, UserEM>("USP_User_Find", UserEM.MapUser, "Id", param).FirstOrDefault();
        }

        public void ChangePassword(int id, byte[] passwordHash, byte[] salt)
        {
            var param = ParametersHelper.CreateFromObject(new { passwordHash, salt }).IncludeId(id);
            ExecuteSP("USP_User_ChangePassword", param);
        }
    }
}
