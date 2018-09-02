using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TicketMS.API.Infrastructure.Configuration
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public string SecurityAlgorithm { get; set; }
        public int LifeTimeMinutes { get; set; }

        public SymmetricSecurityKey SignInKey
        {
            get => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
