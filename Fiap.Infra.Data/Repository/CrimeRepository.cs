using Dapper;
using Fiap.Domain.Entities;
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
    public class CrimeRepository : ICrimeRepository
    {
        private readonly OrcContext _orcContext;

        public CrimeRepository(OrcContext orcContext)
        {
            _orcContext = orcContext;
        }

        public async Task<bool> Create(Crime create)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(CrimeQueries.Insert, create);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int delete)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(CrimeQueries.Delete, new
            {
                Id = delete
            });

            return affectedRows > 0;
        }

        public async Task<List<Crime>> GetAll()
        {
            var crimes = await _orcContext.Connection.QueryAsync<Crime>(CrimeQueries.GetAll);

            return crimes.ToList();
        }

        public async Task<Crime> GetById(int id)
        {
            var crimes = await _orcContext.Connection.QueryFirstOrDefaultAsync<Crime>(CrimeQueries.GetById, new
            {
                Id = id
            });

            return crimes;
        }

        public async Task<bool> Update(Crime update)
        {
            var affectedRows = await _orcContext.Connection.ExecuteAsync(CrimeQueries.Update, update);

            return affectedRows > 0;
        }
    }
}
