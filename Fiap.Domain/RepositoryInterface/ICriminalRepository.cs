using Fiap.Domain.Entities;
using Fiap.Domain.Models;

namespace Fiap.Domain.RepositoryInterface
{
    public interface ICriminalRepository
    {
        Task<bool> Create(Criminal create);
        Task<List<Criminal>> GetAll();
        Task<Criminal> GetById(int id);
        Task<bool> Update(Criminal update);
        Task<bool> Delete(int delete);
    }
}
