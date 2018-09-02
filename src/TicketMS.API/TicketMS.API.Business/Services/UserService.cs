using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Repositories;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels.User;

namespace TicketMS.API.Business.Services
{
    public class UserService : Service, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IMappingService mapper, IUserRepository userRepository) : base(mapper)
        {
            this.userRepository = userRepository;
        }

        public UserVM FindUser(int id)
        {
            var userEM = userRepository.GetUser(id);
            return mapper.ConvertTo<UserVM>(userEM);
        }

        public UserVM FindUser(string emailOrUserName)
        {
            var userEM = userRepository.FindUser(emailOrUserName);
            return mapper.ConvertTo<UserVM>(userEM);
        }
    }
}
