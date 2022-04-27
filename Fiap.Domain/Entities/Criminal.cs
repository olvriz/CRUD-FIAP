using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Entities
{
    public class Criminal
    {
        public Criminal() { }

        public Criminal(CriminalCreateRequest criminal)
        {            
            Age = criminal.Age;
            Ethnicity = criminal.Ethnicity;
            Gender = criminal.Gender;
        }

        public Criminal(CriminalUpdateRequest criminal)
        {
            Id = criminal.Id;
            Age = criminal.Age;
            Ethnicity = criminal.Ethnicity;
            Gender = criminal.Gender;
        }

        public int Id { get; set; }
        public int Age { get; set; }
        public string Ethnicity { get; set; } = string.Empty;
        public char Gender { get; set; }
    }
}
