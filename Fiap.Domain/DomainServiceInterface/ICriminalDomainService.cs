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
    public interface ICriminalDomainService
    {
        Task<bool> Create(CriminalCreateRequest create);
        Task<List<Criminal>> GetAll();
        Task<Criminal> GetById(int id);
        Task<bool> Update(CriminalUpdateRequest update);
        Task<bool> Delete(int id);
    }
}
