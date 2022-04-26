using Fiap.Domain.Entities;
using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.RepositoryInterface
{
    public interface IUserRepository
    {
        User? GetUser(string email);
        Task<int> GetUserId(string email);
        Task<bool> UserAlreadyExists(string email);
        Task<bool> RegistryUser(UserCreateRequest userCreate);               
    }
}
