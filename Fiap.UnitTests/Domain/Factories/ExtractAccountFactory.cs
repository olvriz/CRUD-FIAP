using Fiap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChellenge.UnitTests.Domain.Factories
{
    public static class ExtractAccountFactory
    {
        public static List<AccountTransaction> GetTransactions()
        {
            var date = DateTime.Now;
            return new List<AccountTransaction>
            {
                new AccountTransaction(10, 'C', date, "Account Credit"),
                new AccountTransaction(12.9m, 'C', date, "Account Credit"),
                new AccountTransaction(15.85m, 'D', date, "Account Debit"),
                new AccountTransaction(187, 'C', date, "Account Credit")
            };
        }

        public static List<AccountTransaction>? GetNullTransactions()
        {
            return null;
        }
    }
}
