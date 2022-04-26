using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Models
{
    public class ExtractResponse
    {
        public ExtractResponse(List<AccountTransaction> transactions)
        {
            Transactions = transactions;
        }

        public List<AccountTransaction>? Transactions { get; set; } = null;
    }
}
