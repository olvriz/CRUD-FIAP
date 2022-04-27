using Fiap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.RepositoryInterface
{
    public interface ICrimeRepository
    {
        Task<bool> Create(Crime create);
        Task<List<Crime>> GetAll();
        Task<Crime> GetById(int id);
        Task<bool> Update(Crime update);
        Task<bool> Delete(int delete);
    }
}
