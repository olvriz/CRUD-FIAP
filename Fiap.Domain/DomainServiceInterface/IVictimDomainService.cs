using Fiap.Domain.Entities;
using Fiap.Domain.Models;
using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.DomainServiceInterface
{
    public interface IVictimDomainService
    {
        Task<bool> CreateVictim(VictimCreateRequest victimCreate);
        Task<List<Victim>> GetVictims();
        Task<Victim> GetVictimById(int victimId);
        Task<bool> UpdateVictim(VictimUpdateRequest victimUpdate);
        Task<bool> DeleteVictim(int victimId);
    }
}
