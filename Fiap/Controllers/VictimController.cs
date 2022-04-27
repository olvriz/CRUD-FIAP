using Microsoft.AspNetCore.Mvc;
using Fiap.Domain.DomainServiceInterface;
using Fiap.Domain.Enums;
using Fiap.Domain.Extensions;
using Fiap.Domain.Models.Request;
using Fiap.Domain.Strings;

namespace Fiap.Api.Controllers
{
    [Route("api/victim")]
    public class VictimController : ControllerBase
    {
        private readonly IVictimDomainService _victimDomainService;

        public VictimController(IVictimDomainService victimDomainService)
        {
            _victimDomainService = victimDomainService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVictim([FromBody] VictimCreateRequest VictimCreate)
        {
            try
            {

                var hasSuccess = await _victimDomainService.CreateVictim(VictimCreate);  

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

        [HttpGet]
        public async Task<IActionResult> GetVictims()
        {
            try
            {

                return Ok(await _victimDomainService.GetVictims());
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

        [HttpGet("{victimId}")]
        public async Task<IActionResult> GetVictimById([FromRoute] int victimId)
        {
            try
            {

                return Ok(await _victimDomainService.GetVictimById(victimId));
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

        [HttpPut]
        public async Task<IActionResult> UpdateVictim([FromBody] VictimUpdateRequest victimUpdate)
        {
            try
            {

                var hasSuccess = await _victimDomainService.UpdateVictim(victimUpdate);

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


        [HttpDelete("{victimId}")]
        public async Task<IActionResult> DeleteVictim([FromRoute] int victimId)
        {
            try
            {
                var hasSuccess = await _victimDomainService.DeleteVictim(victimId);

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

    }
}
