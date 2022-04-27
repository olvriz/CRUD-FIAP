using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Models.Request
{
    public class VictimCreateRequest
    {
        public int Age { get; set; }
        public string Ethnicity { get; set; } = string.Empty;
        public char Gender { get; set; }


    }
}
