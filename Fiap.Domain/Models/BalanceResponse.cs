using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Models
{
    public class BalanceResponse
    {
        public BalanceResponse(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; set; }
    }
}
