using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Entities
{
    public class Victim
    {
        public Victim() { }
        public Victim(VictimCreateRequest victim)
        {            
            Age = victim.Age;
            Ethnicity = victim.Ethnicity;
            Gender = victim.Gender;
        }

        public Victim(VictimUpdateRequest victim)
        {
            Id = victim.VictimId;
            Age = victim.Age;
            Ethnicity = victim.Ethnicity;
            Gender = victim.Gender;
        }

        public int Id { get; set; }
        public int Age { get; set; }
        public string Ethnicity { get; set; } = string.Empty;
        public char Gender { get; set; }
    }
}
