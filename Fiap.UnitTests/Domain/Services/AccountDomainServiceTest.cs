using Moq;
using Fiap.Domain.DomainService;
using Fiap.Domain.Extensions;
using Fiap.Domain.Models;
using Fiap.Domain.RepositoryInterface;
using Fiap.Domain.Strings;
using StoneChellenge.UnitTests.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StoneChellenge.UnitTests.Domain.Services
{
    
    public class AccountDomainServiceTest
    {       
        [Fact]
        public async Task GetAccountBalance_ExpectSuccess()
        {
            int userId = 1;
            int? accountId = 1;

            decimal expectedBalance = 15.22m;

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(userId)).Returns(Task.FromResult(accountId));
            accountRepository.Setup(x => x.GetCurrentAccountBalance(accountId.Value)).Returns(Task.FromResult(expectedBalance));

            var accountDomainService = new AccountDomainService(accountRepository.Object);

            var response = await accountDomainService.GetAccountBalanceByUser(userId);

            Assert.Equal(response.Amount, expectedBalance);
        }

        [Fact]
        public async Task GetAccountBalance_InvalidUser_ExpectFail()
        {
            int invalidUserId = 1;
            int? accountId = null;                        

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(invalidUserId)).Returns(Task.FromResult(accountId));            

            var accountDomainService = new AccountDomainService(accountRepository.Object);            

            await Assert.ThrowsAsync<ApplicationException>(() => accountDomainService.GetAccountBalanceByUser(invalidUserId));
        }

        [Fact]
        public async Task GetAccountFutureBalance_ExpectSuccess()
        {
            int userId = 1;
            int? accountId = 1;
            DateTime date = DateTime.Now.AddDays(7);

            decimal currentBalance = 10;
            decimal futureBalance = 5.85m;

            decimal expectedBalance = currentBalance + futureBalance;

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(userId)).Returns(Task.FromResult(accountId));
            accountRepository.Setup(x => x.GetCurrentAccountBalance(accountId.Value)).Returns(Task.FromResult(currentBalance));
            accountRepository.Setup(x => x.GetFutureAccountBalance(accountId.Value, date)).Returns(Task.FromResult(futureBalance));

            var accountDomainService = new AccountDomainService(accountRepository.Object);

            var response = await accountDomainService.GetFutureAccountBalanceByUser(userId, date);

            Assert.Equal(response.Amount, expectedBalance);
        }

        [Fact]
        public async Task GetAccountFutureBalance_InvalidUser_ExpectFail()
        {
            int invalidUserId = 1;
            int? accountId = null;
            DateTime date = DateTime.Now.AddDays(7);

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(invalidUserId)).Returns(Task.FromResult(accountId));

            var accountDomainService = new AccountDomainService(accountRepository.Object);

            await Assert.ThrowsAsync<ApplicationException>(() => accountDomainService.GetFutureAccountBalanceByUser(invalidUserId, date));
        }

        [Fact]
        public async Task CreditAccount_CurrentDate_ExpectSuccess()
        {
            int userId = 1;
            int? accountId = 1;
            var creditRequest = CreditAccountFactory.GetValidCreditAmountRequest();

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(userId)).Returns(Task.FromResult(accountId));
            accountRepository.Setup(x => x.RegistryAccountCredit(accountId.Value, creditRequest.Amount, creditRequest.Resume)).Returns(true);

            var accountDomainService = new AccountDomainService(accountRepository.Object);

            var response = await accountDomainService.CreditUserAccount(creditRequest, userId);

            Assert.True(response);
        }

        [Fact]
        public async Task CreditAccount_FutureDate_ExpectSuccess()
        {
            int userId = 1;
            int? accountId = 1;
            var creditRequest = CreditAccountFactory.GetValidFutureCreditAmountRequest();
            var creditDate = creditRequest.CreditDate ?? DateTime.Now;

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(userId)).Returns(Task.FromResult(accountId));
            accountRepository.Setup(x => x.RegistryFutureAccountCredit(accountId.Value, creditRequest.Amount, creditDate, creditRequest.Resume)).Returns(true);

            var accountDomainService = new AccountDomainService(accountRepository.Object);

            var response = await accountDomainService.CreditUserAccount(creditRequest, userId);

            Assert.True(response);
        }

        [Fact]
        public async Task CreditAccount_InvalidFutureDate_ExpectFail()
        {
            int userId = 1;
            int? accountId = 1;
            var creditRequest = CreditAccountFactory.GetInvalidFutureCreditAmountRequest();
            var creditDate = creditRequest.CreditDate ?? DateTime.Now;

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(userId)).Returns(Task.FromResult(accountId));
            accountRepository.Setup(x => x.RegistryFutureAccountCredit(accountId.Value, creditRequest.Amount, creditDate, creditRequest.Resume)).Returns(true);

            var accountDomainService = new AccountDomainService(accountRepository.Object);            

            await Assert.ThrowsAsync<ApplicationException>(() => accountDomainService.CreditUserAccount(creditRequest, userId));
        }

        [Fact]
        public async Task CreditAccount_InvalidUser_ExpectFail()
        {
            int invalidUserId = 1;
            int? accountId = null;
            var creditRequest = CreditAccountFactory.GetValidCreditAmountRequest();

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(invalidUserId)).Returns(Task.FromResult(accountId));

            var accountDomainService = new AccountDomainService(accountRepository.Object);

            await Assert.ThrowsAsync<ApplicationException>(() => accountDomainService.CreditUserAccount(creditRequest, invalidUserId));
        }

        [Fact]
        public async Task CreditAccount_InvalidAmount_ExpectFail()
        {
            int userId = 1;
            int? accountId = 1;
            var creditRequest = CreditAccountFactory.GetInvalidCreditAmountRequest();

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(userId)).Returns(Task.FromResult(accountId));
            accountRepository.Setup(x => x.RegistryAccountCredit(accountId.Value, creditRequest.Amount, creditRequest.Resume)).Returns(true);

            var accountDomainService = new AccountDomainService(accountRepository.Object);            

            await Assert.ThrowsAsync<ApplicationException>(() => accountDomainService.CreditUserAccount(creditRequest, userId));
        }

        [Fact]
        public async Task DebitAccount_ExpectSuccess()
        {
            int userId = 1;
            int? accountId = 1;

            decimal debitValue = 5;
            decimal accountBalance = 100;

            var debitRequest = DebitAccountFactory.GetDebitAmountRequest(debitValue);            

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(userId)).Returns(Task.FromResult(accountId));
            accountRepository.Setup(x => x.GetCurrentAccountBalance(accountId.Value)).Returns(Task.FromResult(accountBalance));
            accountRepository.Setup(x => x.RegistryAcccountDebit(accountId.Value, debitRequest.Amount, debitRequest.Resume)).Returns(true);

            var accountDomainService = new AccountDomainService(accountRepository.Object);

            var response = await accountDomainService.DebitUserAccount(debitRequest, userId);

            Assert.True(response);
        }

        [Fact]
        public async Task DebitAccount_InvalidUser_ExpectFail()
        {
            int invalidUserId = 1;
            int? accountId = null;
            var creditRequest = DebitAccountFactory.GetDebitAmountRequest(5);

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(invalidUserId)).Returns(Task.FromResult(accountId));

            var accountDomainService = new AccountDomainService(accountRepository.Object);

            await Assert.ThrowsAsync<ApplicationException>(() => accountDomainService.DebitUserAccount(creditRequest, invalidUserId));
        }

        [Fact]
        public async Task DebitAccount_InsuficientFounds_ExpectFail()
        {
            int userId = 1;
            int? accountId = 1;

            decimal debitValue = 150;
            decimal accountBalance = 100;

            var debitRequest = DebitAccountFactory.GetDebitAmountRequest(debitValue);            

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(userId)).Returns(Task.FromResult(accountId));
            accountRepository.Setup(x => x.GetCurrentAccountBalance(accountId.Value)).Returns(Task.FromResult(accountBalance));
            accountRepository.Setup(x => x.RegistryAcccountDebit(accountId.Value, debitRequest.Amount, debitRequest.Resume)).Returns(true);

            var accountDomainService = new AccountDomainService(accountRepository.Object);            

            await Assert.ThrowsAsync<ApplicationException>(() => accountDomainService.DebitUserAccount(debitRequest, userId));
        }

        [Fact]
        public async Task AccountExtract_ExpectSuccess()
        {
            int userId = 1;
            int? accountId = 1;

            DateTime initialDate = DateTime.Now.AddDays(-7);
            DateTime finishDate = DateTime.Now;

            DateTime sanitizedInitialDate = initialDate.ToInitialTime();
            DateTime sanitizedFinishDate = finishDate.ToFinalTime();

            var transactions = ExtractAccountFactory.GetTransactions();

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(userId)).Returns(Task.FromResult(accountId));
            accountRepository.Setup(x => x.GetAccountExtract(accountId.Value, sanitizedInitialDate, sanitizedFinishDate)).Returns(Task.FromResult(transactions));            

            var accountDomainService = new AccountDomainService(accountRepository.Object);
            
            var response = await accountDomainService.GetAccountExtract(userId, initialDate, finishDate);

            Assert.Equal(transactions, response.Transactions);
        }

        [Fact]
        public async Task AccountExtract__InvalidUser_ExpectFail()
        {
            int invalidUserId = 1;
            int? accountId = null;

            DateTime initialDate = DateTime.Now.AddDays(-7);
            DateTime finishDate = DateTime.Now;
           
            var transactions = ExtractAccountFactory.GetTransactions();

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(invalidUserId)).Returns(Task.FromResult(accountId));            

            var accountDomainService = new AccountDomainService(accountRepository.Object);            

            await Assert.ThrowsAsync<ApplicationException>(() => accountDomainService.GetAccountExtract(invalidUserId, initialDate, finishDate));
        }

        [Fact]
        public async Task AccountExtract_NoResults_ExpectSuccess()
        {
            int userId = 1;
            int? accountId = 1;

            DateTime initialDate = DateTime.Now.AddDays(-7);
            DateTime finishDate = DateTime.Now;

            DateTime sanitizedInitialDate = initialDate.ToInitialTime();
            DateTime sanitizedFinishDate = finishDate.ToFinalTime();

            var transactions = ExtractAccountFactory.GetNullTransactions();

            var accountRepository = new Mock<IAccountRepository>();
            accountRepository.Setup(x => x.GetUserAccountId(userId)).Returns(Task.FromResult(accountId));
#pragma warning disable CS8604 
            accountRepository.Setup(x => x.GetAccountExtract(accountId.Value, sanitizedInitialDate, sanitizedFinishDate)).Returns(Task.FromResult(transactions));
#pragma warning restore CS8604 

            var accountDomainService = new AccountDomainService(accountRepository.Object);

            var response = await accountDomainService.GetAccountExtract(userId, initialDate, finishDate);

            Assert.Equal(transactions, response.Transactions);
        }

    }
}
