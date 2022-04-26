using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Models
{
    public class AccessToken
    {
        public bool IsAuthenticated { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }

    }
}
