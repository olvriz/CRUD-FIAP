using Dapper;
using Fiap.Domain.Entities;
using Fiap.Domain.Models.Request;
using Fiap.Domain.RepositoryInterface;
using Fiap.Infra.Data.Context;
using Fiap.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Repository
{
    public class VictimRepository : IVictimRepository
    {
        private readonly OrcContext _orcContext;

        public VictimRepository(OrcContext orcContext)
        {
            _orcContext = orcContext;
        }

        public async Task<bool> CreateVictim(Victim victimCreate)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(VictimQueries.InsertVictim, victimCreate);
            
            return affectedRows > 0;
        }

        public async Task<bool> DeleteVictim(int victimId)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(VictimQueries.DeleteVictim, new
            {
                Id = victimId
            });

            return affectedRows > 0;
        }

        public async Task<Victim> GetVictimById(int victimId)
        {

            var victim = await _orcContext.Connection.QueryFirstOrDefaultAsync<Victim>(VictimQueries.GetVictimById, new
            {
                Id = victimId
            });

            return victim;
        }

        public async Task<List<Victim>> GetVictims()
        {
            var victims = await _orcContext.Connection.QueryAsync<Victim>(VictimQueries.GetAllVictims);

            return victims.ToList();
        }

        public async Task<bool> UpdateVictim(Victim victimUpdate)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(VictimQueries.UpdateVictim, victimUpdate);

            return affectedRows > 0;
        }
    }
}
