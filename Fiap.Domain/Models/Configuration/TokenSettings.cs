using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Models.Configuration
{
    public class TokenSettings
    {
        public TokenSettings(int expirationHours, string issuer, string audience, string tokenAuthType)
        {
            ExpirationHours = expirationHours;
            Issuer = issuer;
            Audience = audience;
            TokenAuthType = tokenAuthType;
        }

        public int ExpirationHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string TokenAuthType { get; set; }
    }
}
