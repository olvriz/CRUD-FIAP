using Microsoft.AspNetCore.Mvc;
using Fiap.Domain.DomainServiceInterface;
using Fiap.Domain.Enums;
using Fiap.Domain.Extensions;
using Fiap.Domain.Models.Request;
using Fiap.Domain.Strings;

namespace Fiap.Api.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserDomainService _userDomainService;

        public UserController(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserCreateRequest userCreate)
        {
            try
            {
                var hasSuccess = await _userDomainService.RegisytryUser(userCreate);

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

        [HttpPost("auth")]
        public IActionResult AuthenticateUser([FromBody] AuthenticateRequest authenticate)
        {
            try
            {
                var accessToken = _userDomainService.GetUserAccessToken(authenticate);

                return Ok(accessToken);
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
