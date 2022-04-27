using Fiap.Domain.Entities;
using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.RepositoryInterface
{
    public interface IVictimRepository
    {
        Task<bool> CreateVictim(Victim victimCreate);
        Task<List<Victim>> GetVictims();
        Task<Victim> GetVictimById(int victimId);
        Task<bool> UpdateVictim(Victim victimUpdate);
        Task<bool> DeleteVictim(int victimId);
    }
}
