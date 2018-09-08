using TicketMS.API.Infrastructure.Common.Models.Security;
using TicketMS.API.ViewModels.User;

namespace TicketMS.API.ViewModels.Account
{
    public class SignInResponseVM
    {
        public JsonWebToken Token { get; set; }
        public UserVM User { get; set; }
    }
}
