using Fiap.Domain.Strings;
using Fiap.Domain.DomainServiceInterface;
using Fiap.Domain.Extensions;
using Fiap.Domain.Models;
using Fiap.Domain.Models.Request;
using Fiap.Domain.RepositoryInterface;
using Fiap.Domain.Entities;

namespace Fiap.Domain.DomainService
{
    public class CriminalDomainService : ICriminalDomainService
    {
        private readonly ICriminalRepository _criminalRepository;

        public CriminalDomainService(ICriminalRepository criminalRepository)
        {
            _criminalRepository = criminalRepository;
        }

        public async Task<bool> Create(CriminalCreateRequest create)
        {
            return await _criminalRepository.Create(new Criminal(create));
        }

        public async Task<bool> Delete(int id)
        {
            return await _criminalRepository.Delete(id);
        }

        public async Task<List<Criminal>> GetAll()
        {
            return await _criminalRepository.GetAll();
        }

        public async Task<Criminal> GetById(int id)
        {
            return await _criminalRepository.GetById(id);
        }

        public async Task<bool> Update(CriminalUpdateRequest update)
        {
            return await _criminalRepository.Update(new Criminal(update));
        }
    }
}
