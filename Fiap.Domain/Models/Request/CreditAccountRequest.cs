using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Models.Request
{
    public class CreditAccountRequest
    {
        public CreditAccountRequest() { }
        public CreditAccountRequest(decimal amount, string? resume = null, DateTime? creditDate = null)
        {
            Amount = amount;
            CreditDate = creditDate;
            Resume = resume;
        }

        public decimal Amount { get; set; }
        public DateTime? CreditDate { get; set; }
        public string? Resume { get; set; }
    }
}
