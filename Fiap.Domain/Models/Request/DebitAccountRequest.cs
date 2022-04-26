using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Models.Request
{
    public class DebitAccountRequest
    {
        public DebitAccountRequest() { }
        public DebitAccountRequest(decimal amount, string? resume = null)
        {
            Amount = amount;
            Resume = resume;
        }

        public decimal Amount { get; set; }
        public string? Resume { get; set; }
    }
}
