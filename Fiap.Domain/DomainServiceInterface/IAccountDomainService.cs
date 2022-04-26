using Fiap.Domain.Models;
using Fiap.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.DomainServiceInterface
{
    public interface IAccountDomainService
    {
        Task<BalanceResponse> GetAccountBalanceByUser(int userId);
        Task<BalanceResponse> GetFutureAccountBalanceByUser(int userId, DateTime date);
        Task<bool> CreditUserAccount(CreditAccountRequest creditInfo, int userId);
        Task<bool> DebitUserAccount(DebitAccountRequest debitInfo, int userId);
        Task<ExtractResponse> GetAccountExtract(int userId, DateTime initialDate, DateTime finishDate);
    }
}
