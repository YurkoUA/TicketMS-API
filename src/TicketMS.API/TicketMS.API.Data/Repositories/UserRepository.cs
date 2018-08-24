using System.Linq;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.Database;
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
            var param = ParametersHelper.CreateFromObject(new { id });
            return _Get("USP_User_Get", param);
        }

        public UserEM FindUser(string emailOrUserName)
        {
            var param = ParametersHelper.CreateFromObject(new { emailOrUserName });
            return _Get("USP_User_Find", param);
        }

        public void ChangePassword(int id, byte[] passwordHash, byte[] salt)
        {
            var param = ParametersHelper.CreateFromObject(new
            {
                id, passwordHash, salt
            });
            ExecuteSP("USP_User_ChangePassword", param);
        }

        private UserEM _Get(string spName, object param)
        {
            return ExecuteSP<UserEM, RoleEM, UserEM>(spName, (user, role) =>
            {
                user.Role = role;
                return user;
            }, "Id", param).FirstOrDefault();
        }
    }
}
