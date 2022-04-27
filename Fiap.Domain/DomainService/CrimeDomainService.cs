using Fiap.Domain.DomainServiceInterface;
using Fiap.Domain.Entities;
using Fiap.Domain.Models.Request;
using Fiap.Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.DomainService
{
    public class CrimeDomainService : ICrimeDomainService
    {

        private readonly ICrimeRepository _crimeRepository;
        private readonly ICriminalRepository _criminalRepository;
        private readonly IVictimRepository _victimRepository;

        public CrimeDomainService(ICrimeRepository crimeRepository, ICriminalRepository criminalRepository, IVictimRepository victimRepository)
        {
            _crimeRepository = crimeRepository;
            _criminalRepository = criminalRepository;
            _victimRepository = victimRepository;
        }

        public async Task<bool> Create(CrimeCreateRequest create)
        {
            var victim = await _victimRepository.GetVictimById(create.VictimId);

            if (victim == null)
                throw new ApplicationException("A vítima informada não existe");

            var criminal = await _criminalRepository.GetById(create.CriminalId);

            if (criminal == null)
                throw new ApplicationException("O criminoso informado não existe");

            return await _crimeRepository.Create(new Crime(create));
        }

        public async Task<bool> Delete(int id)
        {
            return await _crimeRepository.Delete(id);
        }

        public async Task<List<Crime>> GetAll()
        {
            return await _crimeRepository.GetAll();
        }

        public async Task<Crime> GetById(int id)
        {
            return await _crimeRepository.GetById(id);
        }

        public async Task<bool> Update(CrimeUpdateRequest update)
        {
            var victim = await _victimRepository.GetVictimById(update.VictimId);

            if (victim == null)
                throw new ApplicationException("A vítima informada não existe");

            var criminal = await _criminalRepository.GetById(update.CriminalId);

            if (criminal == null)
                throw new ApplicationException("O criminoso informado não existe");

            return await _crimeRepository.Update(new Crime(update));
        }
    }
}
