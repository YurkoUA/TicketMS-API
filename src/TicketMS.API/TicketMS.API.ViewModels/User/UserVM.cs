namespace TicketMS.API.ViewModels.User
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string TelegramId { get; set; }

        public RoleVM Role { get; set; }
    }
}
