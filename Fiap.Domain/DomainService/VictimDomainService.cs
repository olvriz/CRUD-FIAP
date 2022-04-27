using Microsoft.IdentityModel.Tokens;
using Fiap.Domain.Auth;
using Fiap.Domain.DomainServiceInterface;
using Fiap.Domain.Entities;
using Fiap.Domain.Models;
using Fiap.Domain.Models.Request;
using Fiap.Domain.RepositoryInterface;
using Fiap.Domain.ServiceInterface;
using Fiap.Domain.Strings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.DomainService
{
    public class VictimDomainService : IVictimDomainService
    {
        private readonly IVictimRepository _victimRepository;

        public VictimDomainService(IVictimRepository victimRepository)
        {
            _victimRepository = victimRepository;
        }

        public async Task<bool> CreateVictim(VictimCreateRequest victimCreate)
        {
            return await _victimRepository.CreateVictim(new Victim(victimCreate));
        }

        public async Task<bool> DeleteVictim(int victimId)
        {
            return await _victimRepository.DeleteVictim(victimId);
        }

        public async Task<List<Victim>> GetVictims()
        {
            return await _victimRepository.GetVictims();
        }

        public async Task<Victim> GetVictimById(int victimId)
        {
            return await _victimRepository.GetVictimById(victimId);
        }

        public async Task<bool> UpdateVictim(VictimUpdateRequest victimUpdate)
        {
            return await _victimRepository.UpdateVictim(new Victim(victimUpdate));
        }
    }
}
