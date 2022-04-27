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
    [Route("api/criminal")]
    public class CriminalController : ControllerBase
    {
        private readonly ICriminalDomainService _criminalDomainService;

        public CriminalController(ICriminalDomainService criminalDomainService)
        {
            _criminalDomainService = criminalDomainService;
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CriminalCreateRequest createRequest)
        {
            try
            {

                var hasSuccess = await _criminalDomainService.Create(createRequest);

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
        public async Task<IActionResult> GetAll()
        {
            try
            {

                return Ok(await _criminalDomainService.GetAll());
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {

                return Ok(await _criminalDomainService.GetById(id));
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
        public async Task<IActionResult> Update([FromBody] CriminalUpdateRequest update)
        {
            try
            {

                var hasSuccess = await _criminalDomainService.Update(update);

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


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var hasSuccess = await _criminalDomainService.Delete(id);

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
