using Fiap.Domain.Models;
using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.DomainServiceInterface
{
    public interface IUserDomainService
    {
        AccessToken GetUserAccessToken(AuthenticateRequest authenticate);
        Task<bool> RegisytryUser(UserCreateRequest userCreate);
    }
}
