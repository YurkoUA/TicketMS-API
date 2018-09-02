using System.Collections.Generic;
using System.Text;

namespace TicketMS.API.Data.Entity
{
    public class UserEM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int TelegramId { get; set; }

        public RoleEM Role { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }

        public byte[] GetIdentityBytes(string password)
        {
            var bytes = new List<byte>();

            bytes.AddRange(Encoding.ASCII.GetBytes(password));
            bytes.AddRange(Encoding.ASCII.GetBytes(Email));
            bytes.AddRange(Encoding.ASCII.GetBytes(UserName));

            return bytes.ToArray();
        }

        public static UserEM MapUser(UserEM user, RoleEM role)
        {
            user.Role = role;
            return user;
        }
    }
}
