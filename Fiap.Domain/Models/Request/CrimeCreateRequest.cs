using Fiap.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Models.Request
{
    public class CrimeCreateRequest
    {
        public CrimeType CrimeType { get; set; }
        public DateTime OcorrenceDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public int CriminalId { get; set; }
        public int VictimId { get; set; }

    }
}
