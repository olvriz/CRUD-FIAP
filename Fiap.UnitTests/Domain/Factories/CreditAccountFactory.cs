using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChellenge.UnitTests.Domain.Factories
{
    public class CreditAccountFactory
    {
        public static CreditAccountRequest GetValidCreditAmountRequest()
        {
            return new CreditAccountRequest(15.90m);
        }

        public static CreditAccountRequest GetInvalidCreditAmountRequest()
        {
            return new CreditAccountRequest(-1);
        }

        public static CreditAccountRequest GetValidFutureCreditAmountRequest()
        {
            return new CreditAccountRequest(15.90m, null, DateTime.Now.AddDays(7));
        }

        public static CreditAccountRequest GetInvalidFutureCreditAmountRequest()
        {
            return new CreditAccountRequest(15.90m, null, DateTime.Now.AddDays(-7));
        }

        
    }
}
