using System.Security.Claims;
using TicketMS.API.Infrastructure.Configuration;
using TicketMS.API.Infrastructure.Models.Security;

namespace TicketMS.API.Infrastructure.Services
{
    public interface IJwtService
    {
        JsonWebToken CreateJwt(ClaimsIdentity claims, JwtOptions jwtOptions);
    }
}
