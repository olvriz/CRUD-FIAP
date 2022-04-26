using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneChellenge.UnitTests.Domain.Factories
{
    public class DebitAccountFactory
    {
        public static DebitAccountRequest GetDebitAmountRequest(decimal amount)
        {
            return new DebitAccountRequest(amount);
        }
       
    }
}
