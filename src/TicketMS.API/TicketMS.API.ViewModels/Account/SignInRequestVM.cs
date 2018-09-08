using System.ComponentModel.DataAnnotations;

namespace TicketMS.API.ViewModels.Account
{
    public class SignInRequestVM
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
