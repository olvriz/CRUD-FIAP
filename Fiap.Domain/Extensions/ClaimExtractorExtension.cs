using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Extensions
{
    public static class ClaimExtractorExtension
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var value = principal.FindFirst("id")?.Value;

            if (string.IsNullOrEmpty(value))
                return 0;            

            return int.Parse(value);
        }
    }
}
