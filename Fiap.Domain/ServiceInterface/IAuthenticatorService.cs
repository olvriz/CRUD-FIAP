using Fiap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.ServiceInterface
{
    public interface IAuthenticatorService
    {
        AccessToken GenerateAccessToken(int userId);
    }
}
