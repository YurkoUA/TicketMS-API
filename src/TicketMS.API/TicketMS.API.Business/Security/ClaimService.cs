using System.Collections.Generic;
using System.Security.Claims;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.Services;

namespace TicketMS.API.Business.Security
{
    public class ClaimService : IClaimService
    {
        public ClaimsIdentity CreateClaims(UserEM user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
