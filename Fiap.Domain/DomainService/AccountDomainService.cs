using Fiap.Domain.Strings;
using Fiap.Domain.DomainServiceInterface;
using Fiap.Domain.Extensions;
using Fiap.Domain.Models;
using Fiap.Domain.Models.Request;
using Fiap.Domain.RepositoryInterface;


namespace Fiap.Domain.DomainService
{
    public class AccountDomainService : IAccountDomainService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountDomainService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        private async Task<int> GetAndValidateUserAccountId(int userId)
        {
            var accountId = await _accountRepository.GetUserAccountId(userId);

            if (accountId == null)
                throw new ApplicationException(ErrorMessages.NotAccountHolder);

            return accountId.Value;
        }

        public async Task<BalanceResponse> GetAccountBalanceByUser(int userId)
        {
            var accountId = await GetAndValidateUserAccountId(userId);

            var accountBalance = await _accountRepository.GetCurrentAccountBalance(accountId);
            
            return new BalanceResponse(accountBalance);            
        }

        public async Task<BalanceResponse> GetFutureAccountBalanceByUser(int userId, DateTime date)
        {
            var accountId = await GetAndValidateUserAccountId(userId);

            var futureAccountBalance = await _accountRepository.GetFutureAccountBalance(accountId, date);
            var accountBalance = await _accountRepository.GetCurrentAccountBalance(accountId);

            accountBalance += futureAccountBalance;

            return new BalanceResponse(accountBalance);
        }

        public async Task<bool> CreditUserAccount(CreditAccountRequest creditInfo, int userId)
        {
            var accountId = await GetAndValidateUserAccountId(userId);

            if (creditInfo.Amount <= 0)
                throw new ApplicationException(ErrorMessages.InvalidAmount);
            
            if (creditInfo.CreditDate.HasValue)
            {
                if (!creditInfo.CreditDate.Value.IsValidSchedulingTime())
                    throw new ApplicationException(ErrorMessages.InvalidSchedulingTime);

                return _accountRepository.RegistryFutureAccountCredit(accountId, creditInfo.Amount, creditInfo.CreditDate.Value, creditInfo.Resume);
            }

            return _accountRepository.RegistryAccountCredit(accountId, creditInfo.Amount, creditInfo.Resume);
        }

        public async Task<bool> DebitUserAccount(DebitAccountRequest debitInfo, int userId)
        {
            var accountId = await GetAndValidateUserAccountId(userId);

            if (debitInfo.Amount <= 0)
                throw new ApplicationException(ErrorMessages.InvalidAmount);

            var accountBalance = await _accountRepository.GetCurrentAccountBalance(accountId);

            if (debitInfo.Amount > accountBalance)
                throw new ApplicationException(ErrorMessages.InsufficientFounds);

            return _accountRepository.RegistryAcccountDebit(accountId, debitInfo.Amount, debitInfo.Resume);
        }

        public async Task<ExtractResponse> GetAccountExtract(int userId, DateTime initialDate, DateTime finishDate)
        {
            var accountId = await GetAndValidateUserAccountId(userId);            

            initialDate = initialDate.ToInitialTime();
            finishDate = finishDate.ToFinalTime();

            var transactions = await _accountRepository.GetAccountExtract(accountId, initialDate, finishDate);

            return new ExtractResponse(transactions);
        }
    }
}
