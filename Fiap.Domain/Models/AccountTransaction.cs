using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Models
{
    public class AccountTransaction
    {
        public AccountTransaction() { }
        public AccountTransaction(decimal value, char type, DateTime transactionDate, string? resume)
        {
            Value = value;
            Type = type;
            TransactionDate = transactionDate;
            Resume = resume;
        }

        public decimal Value { get; set; }
        public char Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Resume { get; set; } = null;
    }
}
