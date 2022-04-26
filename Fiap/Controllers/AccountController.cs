using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Fiap.Domain.Auth;
using Fiap.Domain.DomainServiceInterface;
using Fiap.Domain.Enums;
using Fiap.Domain.Extensions;
using Fiap.Domain.Models.Request;
using Fiap.Domain.Strings;

namespace Fiap.Api.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDomainService _accountDomainService;
        private readonly IUserLogged _userLogged;

        public AccountController(IAccountDomainService accountDomainService, IUserLogged userLogged)
        {
            _accountDomainService = accountDomainService;
            _userLogged = userLogged;
        }
        
        [Authorize]
        [HttpGet("balance")]
        public async Task<IActionResult> GetCurrentBalance()
        {            
            try
            {
                var accountBalance = await _accountDomainService.GetAccountBalanceByUser(_userLogged.Id);

                return Ok(accountBalance);                
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message.ToResponseMessage());                
            }
            catch (Exception e)
            {
#if DEBUG
                return StatusCode(HttpCodes.InternalError, e.Message.ToResponseMessage());
#else
                return StatusCode(HttpCodes.InternalError, ErrorMessages.DefaultErrorMessage.ToResponseMessage());                
#endif                               
            }
        }

        [Authorize]
        [HttpGet("balance/future")]
        public async Task<IActionResult> GetFutureBalance([FromQuery] DateTime balanceDate)
        {
            try
            {
                var futureAccountBalance = await _accountDomainService.GetFutureAccountBalanceByUser(_userLogged.Id, balanceDate);

                return Ok(futureAccountBalance);
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message.ToResponseMessage());
            }
            catch (Exception e)
            {
#if DEBUG
                return StatusCode(HttpCodes.InternalError, e.Message.ToResponseMessage());
#else
                return StatusCode(HttpCodes.InternalError, ErrorMessages.DefaultErrorMessage.ToResponseMessage());                
#endif  
            }
        }

        [Authorize]
        [HttpPost("credit")]
        public async Task<IActionResult> CreditAccount([FromBody] CreditAccountRequest creditAccount)
        {
            try
            {
                var hasSuccess = await _accountDomainService.CreditUserAccount(creditAccount, _userLogged.Id);

                if (!hasSuccess)
                    throw new Exception();

                return StatusCode(HttpCodes.Created);
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message.ToResponseMessage());
            }
            catch (Exception e)
            {
#if DEBUG
                return StatusCode(HttpCodes.InternalError, e.Message.ToResponseMessage());
#else
                return StatusCode(HttpCodes.InternalError, ErrorMessages.DefaultErrorMessage.ToResponseMessage());                
#endif  
            }
        }

        [Authorize]
        [HttpPost("debit")]
        public async Task<IActionResult> DebitAccount([FromBody] DebitAccountRequest debitAccount)
        {
            try
            {
                var hasSuccess = await _accountDomainService.DebitUserAccount(debitAccount, _userLogged.Id);

                if (!hasSuccess)
                    throw new Exception();

                return StatusCode(HttpCodes.NoContent);
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message.ToResponseMessage());
            }
            catch (Exception e)
            {
#if DEBUG
                return StatusCode(HttpCodes.InternalError, e.Message.ToResponseMessage());
#else
                return StatusCode(HttpCodes.InternalError, ErrorMessages.DefaultErrorMessage.ToResponseMessage());                
#endif  
            }
        }

        [Authorize]
        [HttpGet("extract")]
        public async Task<IActionResult> GetAccountExtract([FromQuery] DateTime initialDate, DateTime finishDate)
        {
            try
            {
                var futureAccountBalance = await _accountDomainService.GetAccountExtract(_userLogged.Id, initialDate, finishDate);

                return Ok(futureAccountBalance);
            }
            catch (ApplicationException ae)
            {
                return BadRequest(ae.Message.ToResponseMessage());
            }
            catch (Exception e)
            {
#if DEBUG
                return StatusCode(HttpCodes.InternalError, e.Message.ToResponseMessage());
#else
                return StatusCode(HttpCodes.InternalError, ErrorMessages.DefaultErrorMessage.ToResponseMessage());                
#endif  
            }
        }
    }
}
