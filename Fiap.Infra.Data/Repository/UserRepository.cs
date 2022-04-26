using Dapper;
using Fiap.Domain.Entities;
using Fiap.Domain.Models.Request;
using Fiap.Domain.RepositoryInterface;
using Fiap.Infra.Data.Context;
using Fiap.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MsSqlContext _msSqlContext;

        public UserRepository(MsSqlContext msSqlContext)
        {
            _msSqlContext = msSqlContext;
        }       

        public User? GetUser(string email)
        {
            return _msSqlContext.Connection.QueryFirst<User?>(UserQueries.GetUserByEmail, new
            {
                email
            });            
        }

        public async Task<int> GetUserId(string email)
        {
            return await _msSqlContext.Connection.QueryFirstAsync<int>(UserQueries.GetUserId, new
            {
                email
            });
        }

        public async Task<bool> RegistryUser(UserCreateRequest userCreate)
        {
            var affectedRows = await _msSqlContext.Connection.ExecuteAsync(UserQueries.RegistryUser, new
            {
                name = userCreate.Name,
                email = userCreate.Email,
                passwordHash = userCreate.Password
            });

            return affectedRows > 0;
        }

        public async Task<bool> UserAlreadyExists(string email)
        {
            var user = await _msSqlContext.Connection.QueryAsync<bool?>(UserQueries.UserExistsByEmail, new
            {
                email
            });

            return user.Count() == 1;
        }
    }
}
