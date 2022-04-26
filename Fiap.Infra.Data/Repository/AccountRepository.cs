using Dapper;
using Fiap.Domain.Models;
using Fiap.Domain.RepositoryInterface;
using Fiap.Domain.Strings;
using Fiap.Infra.Data.Context;
using Fiap.Infra.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infra.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MsSqlContext _msSqlContext;

        public AccountRepository(MsSqlContext msSqlContext)
        {
            _msSqlContext = msSqlContext;
        }       

        public async Task<List<AccountTransaction>> GetAccountExtract(int accountId, DateTime initialDatetime, DateTime finishDatetime)
        {
            return (await _msSqlContext.Connection.QueryAsync<AccountTransaction>(AccountQueries.GetAccountExtract, new
            {
                accountId,
                initialDatetime,
                finishDatetime
            })).ToList();
        }

        public async Task<decimal> GetCurrentAccountBalance(int accountId)
        {
            return await _msSqlContext.Connection.QueryFirstAsync<decimal?>(AccountQueries.GetAccountBalance, new
            {
                accountId
            }) ?? 0;
        }

        public async Task<decimal> GetFutureAccountBalance(int accountId, DateTime creditDatetime)
        {
            return await _msSqlContext.Connection.QueryFirstAsync<decimal?>(AccountQueries.GetAccountFutureBalance, new
            {
                accountId,
                creditDatetime
            }) ?? 0;
        }

        public async Task<int?> GetUserAccountId(int userId)
        {
            return await _msSqlContext.Connection.QueryFirstAsync<int?>(AccountQueries.GetUserAccountId, new
            {
                userId
            });
        }       
        public bool RegistryAcccountDebit(int accountId, decimal value, string? resume = null)
        {
            if (resume == null)
                resume = DefaultResumes.NewDebitResume;

            var affectedRows = _msSqlContext.Connection.Execute(AccountQueries.RegistryDebit, new
            {
                accountId,
                value,
                resume
            });

            return affectedRows > 0;
        }

        public bool RegistryAccountCredit(int accountId, decimal value, string? resume = null)
        {
            if (resume == null)
                resume = DefaultResumes.NewCreditResume;

            var affectedRows = _msSqlContext.Connection.Execute(AccountQueries.RegistryCredit, new
            {
                accountId,
                value,                
                resume
            });

            return affectedRows > 0;
        }

        public bool RegistryFutureAccountCredit(int accountId, decimal value, DateTime creditDatetime, string? resume = null)
        {
            if (resume == null)
                resume = DefaultResumes.NewFutureCreditResume;

            var affectedRows = _msSqlContext.Connection.Execute(AccountQueries.RegistryFutureCredit, new
            {
                accountId,
                value,
                creditDatetime,
                resume
            });

            return affectedRows > 0;
        }
        public async Task<bool> CreateUserAccount(int userId)
        {
            var affectedRows = await _msSqlContext.Connection.ExecuteAsync(AccountQueries.RegistryAccount, new
            {
                userId
            });

            return affectedRows > 0;
        }

        public async Task<bool> InsertInitialAccountBalance(int accountId)
        {
            var affectedRows = await _msSqlContext.Connection.ExecuteAsync(AccountQueries.InsertInitialBalance, new
            {
                accountId
            });

            return affectedRows > 0;
        }

    }
}
