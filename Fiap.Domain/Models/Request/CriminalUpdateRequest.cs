using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Models.Request
{
    public class CriminalUpdateRequest : CriminalCreateRequest
    {
        public int Id { get; set; }
    }
}
