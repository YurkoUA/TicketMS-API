namespace TicketMS.API.Data.Entity
{
    public class UserEM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public RoleEM Role { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
    }
}
