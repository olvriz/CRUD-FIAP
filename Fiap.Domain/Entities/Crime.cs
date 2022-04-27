using Fiap.Domain.Enums;
using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Entities
{
    public class Crime
    {
        public Crime() { }

        public Crime(CrimeCreateRequest criminal)
        {            
            CrimeType = criminal.CrimeType;
            OcorrenceDate = criminal.OcorrenceDate;
            Address = criminal.Address;
            CriminalId = criminal.CriminalId;
            VictimId = criminal.VictimId;
        }

        public Crime(CrimeUpdateRequest criminal)
        {
            Id = criminal.Id;
            CrimeType = criminal.CrimeType;
            OcorrenceDate = criminal.OcorrenceDate;
            Address = criminal.Address;
            CriminalId = criminal.CriminalId;
            VictimId = criminal.VictimId;
        }

        public int Id { get; set; }
        public CrimeType CrimeType { get; set; }
        public DateTime OcorrenceDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public int CriminalId { get; set; }
        public int VictimId { get; set; }
    }
}
