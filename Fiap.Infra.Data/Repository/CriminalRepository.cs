using Dapper;
using Fiap.Domain.Entities;
using Fiap.Domain.Models;
using Fiap.Domain.RepositoryInterface;
using Fiap.Domain.Strings;
using Fiap.Infra.Data.Context;
using Fiap.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Repository
{
    public class CriminalRepository : ICriminalRepository
    {
        private readonly OrcContext _orcContext;

        public CriminalRepository(OrcContext orcContext)
        {
            _orcContext = orcContext;
        }

        public async Task<bool> Create(Criminal create)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(CriminalQueries.Insert, create);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int delete)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(CriminalQueries.Delete, new
            {
                Id = delete
            });

            return affectedRows > 0;
        }

        public async Task<List<Criminal>> GetAll()
        {
            var victims = await _orcContext.Connection.QueryAsync<Criminal>(CriminalQueries.GetAll);

            return victims.ToList();
        }

        public async Task<Criminal> GetById(int id)
        {
            var victim = await _orcContext.Connection.QueryFirstOrDefaultAsync<Criminal>(CriminalQueries.GetById, new
            {
                Id = id
            });

            return victim;
        }

        public async Task<bool> Update(Criminal update)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(CriminalQueries.Update, update);

            return affectedRows > 0;
        }
    }
}
