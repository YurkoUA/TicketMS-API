using System;
using System.Linq;
using Microsoft.Extensions.Options;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.Configuration;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Models.Security;
using TicketMS.API.Infrastructure.Repositories;
using TicketMS.API.Infrastructure.Services;

namespace TicketMS.API.Business.Services
{
    public class UserAuthenticationService : Service, IUserAuthenticationService
    {
        private const int SALT_LENGTH = 64;

        private readonly IUserRepository userRepository;
        private readonly ILoginService loginService;
        private readonly ICryptoService cryptoService;
        private readonly IJwtService jwtService;
        private readonly IClaimService claimService;

        private readonly JwtOptions jwtOptions;

        public UserAuthenticationService(
            IMappingService mapper,
            IUserRepository userRepository,
            ILoginService loginService,
            ICryptoService cryptoService,
            IJwtService jwtService,
            IClaimService claimService,
            IOptions<JwtOptions> jwtOptions) : base(mapper)
        {
            this.userRepository = userRepository;
            this.loginService = loginService;
            this.cryptoService = cryptoService;
            this.jwtService = jwtService;
            this.claimService = claimService;
            this.jwtOptions = jwtOptions.Value;
        }

        public JsonWebToken Authenticate(string emailOrUserName, string password)
        {
            var user = userRepository.FindUser(emailOrUserName);

            if (user == null || !CheckPassword(user, password))
                throw new Exception("User is not found.");

            var claims = claimService.CreateClaims(user);
            return jwtService.CreateJwt(claims, jwtOptions);
        }

        public void ChangePassword(int id, string currentPassword, string newPassword)
        {
            var user = userRepository.GetUser(id);

            if (user == null || !CheckPassword(user, currentPassword))
                throw new Exception("The current password is wrong.");

            user.Salt = cryptoService.GenerateRandomBytes(SALT_LENGTH);
            var hash = ComputeHash(user, newPassword);

            userRepository.ChangePassword(id, hash, user.Salt);
        }

        #region Private methods.



        private bool CheckPassword(UserEM user, string password)
        {
            try
            {
                var userHash = ComputeHash(user, password);
                return userHash.SequenceEqual(user.PasswordHash);
            }
            catch
            {
                return false;
            }
        }

        private byte[] ComputeHash(UserEM user, string password)
        {
            return cryptoService.ComputeHash(cryptoService.Xor(user.GetIdentityBytes(password), user.Salt));
        }

        #endregion
    }
}
