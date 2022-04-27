using Fiap.Domain.Entities;
using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.DomainServiceInterface
{
    public interface ICrimeDomainService
    {
        Task<bool> Create(CrimeCreateRequest create);
        Task<List<Crime>> GetAll();
        Task<Crime> GetById(int id);
        Task<bool> Update(CrimeUpdateRequest update);
        Task<bool> Delete(int id);
    }
}
