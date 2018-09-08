using TicketMS.API.ViewModels.User;

namespace TicketMS.API.ViewModels.Account
{
    public class SignInResponseVM
    {
        // It's dynamic to avoid circular dependency between ViewModels and Infrastructure projects.
        public dynamic Token { get; set; }
        public UserVM User { get; set; }
    }
}
