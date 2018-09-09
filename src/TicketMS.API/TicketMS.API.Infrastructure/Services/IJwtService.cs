using System.Security.Claims;
using TicketMS.API.Infrastructure.Common.Models.Security;
using TicketMS.API.Infrastructure.Configuration;

namespace TicketMS.API.Infrastructure.Services
{
    public interface IJwtService
    {
        JsonWebToken CreateJwt(ClaimsIdentity claims, JwtOptions jwtOptions);
    }
}
