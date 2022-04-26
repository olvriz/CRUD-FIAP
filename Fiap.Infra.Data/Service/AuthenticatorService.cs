using Microsoft.IdentityModel.Tokens;
using Fiap.Domain.Auth;
using Fiap.Domain.Models;
using Fiap.Domain.ServiceInterface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Service
{
    public class AuthenticatorService : IAuthenticatorService
    {
        private readonly SigningConfigurations _signingConfigurations;

        private const string USER_ID_CLAIM = "id";
        private const string DEFAULT_ISSUER = "localhost";
        private const string DEFAULT_AUDIENCE = "localhost";
        private const string TOKEN_TYPE = "auth";
        private const byte TOKEN_EXPIRATION_HOURS = 2;

        public AuthenticatorService(SigningConfigurations signingConfigurations)
        {
            _signingConfigurations = signingConfigurations;
        }

        private static List<Claim> GetTokenDefaultClaim(int userId)
        {
            return new List<Claim>
            {
                new Claim(USER_ID_CLAIM, userId.ToString()),
            };
        }

        private static ClaimsIdentity GetTokenClaimIdentity(string session, List<Claim> claims)
        {
            return new ClaimsIdentity(
                new GenericIdentity(
                    session,
                    TOKEN_TYPE),
                claims);
        }

        private SecurityTokenDescriptor GetTokenSecurityDescriptor(ClaimsIdentity identity, DateTime tokenCreationDate, DateTime tokenExpirationDate)
        {
            return new SecurityTokenDescriptor
            {
                Issuer = DEFAULT_ISSUER,
                Audience = DEFAULT_AUDIENCE,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = tokenCreationDate,
                Expires = tokenExpirationDate
            };
        }

        public AccessToken GenerateAccessToken(int userId)
        {
            var sessionIdentifier = Guid.NewGuid().ToString("N");

            var tokenCreationDate = DateTime.Now;
            var tokenExpirationDate = tokenCreationDate.AddHours(TOKEN_EXPIRATION_HOURS);

            var claims = GetTokenDefaultClaim(userId);

            var identity = GetTokenClaimIdentity(sessionIdentifier, claims);

            var handler = new JwtSecurityTokenHandler();
            var tokenDescriptor = GetTokenSecurityDescriptor(identity, tokenCreationDate, tokenExpirationDate);

            var securityToken = handler.CreateToken(tokenDescriptor);

            var token = handler.WriteToken(securityToken);

            return new AccessToken
            {
                Expiration = tokenExpirationDate,
                IsAuthenticated = true,
                Token = token
            };
        }
    }
}
