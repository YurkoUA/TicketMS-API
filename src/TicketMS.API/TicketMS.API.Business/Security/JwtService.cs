using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using TicketMS.API.Infrastructure.Configuration;
using TicketMS.API.Infrastructure.Models.Security;
using TicketMS.API.Infrastructure.Services;

namespace TicketMS.API.Business.Security
{
    public class JwtService : IJwtService
    {
        public JsonWebToken CreateJwt(ClaimsIdentity claims, JwtOptions jwtOptions)
        {
            var utcNow = DateTime.UtcNow;
            var expiresDate = utcNow.AddMinutes(jwtOptions.LifeTimeMinutes);

            var jwt = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                notBefore: utcNow,
                claims: claims.Claims,
                expires: expiresDate,
                signingCredentials: new SigningCredentials(jwtOptions.SignInKey, jwtOptions.SecurityAlgorithm)
            );

            return new JsonWebToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                ExpiresDate = expiresDate
            };
        }
    }
}
