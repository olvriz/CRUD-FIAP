using Fiap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Extensions
{
    public static class StringExtension
    {
        public static ResponseMessage ToResponseMessage(this string message)
        {
            return new ResponseMessage(message);
        }
    }
}
