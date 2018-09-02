using System.Security.Claims;
using TicketMS.API.Data.Entity;

namespace TicketMS.API.Infrastructure.Services
{
    public interface IClaimService
    {
        ClaimsIdentity CreateClaims(UserEM user);
    }
}
