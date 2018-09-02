using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Repositories;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels.User;

namespace TicketMS.API.Business.Services
{
    public class LoginService : Service, ILoginService
    {
        private readonly ILoginRepository loginRepository;

        public LoginService(IMappingService mapper, ILoginRepository loginRepository) : base(mapper)
        {
            this.loginRepository = loginRepository;
        }

        public IEnumerable<LoginVM> GetLogins(int userId, IPaging paging)
        {
            var loginsEM = loginRepository.GetLogins(userId, paging);
            return mapper.ConvertCollectionTo<LoginVM>(loginsEM);
        }

        public void AddLogin(LoginVM login)
        {
            var loginEM = mapper.ConvertTo<LoginEM>(login);
            loginRepository.AddLogin(loginEM);
        }
    }
}
