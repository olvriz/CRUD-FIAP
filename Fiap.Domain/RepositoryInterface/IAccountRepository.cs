using Fiap.Domain.Models;

namespace Fiap.Domain.RepositoryInterface
{
    public interface IAccountRepository
    {
        Task<int?> GetUserAccountId(int userId);
        bool RegistryAcccountDebit(int accountId, decimal value, string? resume = null);
        bool RegistryAccountCredit(int accountId, decimal value, string? resume = null);
        bool RegistryFutureAccountCredit(int accountId, decimal value, DateTime creditDatetime, string? resume = null);
        Task<decimal> GetCurrentAccountBalance(int accountId);
        Task<decimal> GetFutureAccountBalance(int accountId, DateTime creditDatetime);
        Task<List<AccountTransaction>> GetAccountExtract(int accountId, DateTime initialDatetime, DateTime finishDatetime);
        Task<bool> CreateUserAccount(int userId);
        Task<bool> InsertInitialAccountBalance(int accountId);

    }
}
