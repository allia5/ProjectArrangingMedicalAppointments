using DTO;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Doctor.Exceptions;
using Server.Services.Foundation.WorkDoctorService;
using System.Security.Claims;
using System.Transactions;
using static Server.Utility.Utility;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkDoctorController : ControllerBase
    {
        public readonly IWorkDoctorService workDoctorService;
        public WorkDoctorController(IWorkDoctorService workDoctorService)
        {
            this.workDoctorService = workDoctorService;
        }
        [HttpPost("PostInvitationWorkDoctor")]
        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Roles = "ADMIN")]
        public async Task<ActionResult> PostNewInvitationWorkDoctor([FromBody] string IdUser)
        {
            TransactionScope transaction = CreateAsyncTransactionScope(IsolationLevel.ReadCommitted);
            try
            {
                var email = User?.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
                await this.workDoctorService.PostNewInvitationWorkDoctor(email, IdUser);
                transaction.Complete();
                return Ok();
            }
            catch (ValidationException Ex)
            {
                return BadRequest(Ex.InnerException);
            }
            catch (ServiceException Ex)
            {
                return NotFound(Ex.InnerException);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            finally
            {
                transaction.Dispose();
            }
        }
        [HttpGet("GetListInvitationDoctor")]
        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Roles = "MEDECIN")]
        public async Task<ActionResult<List<InvitationsDoctorDto>>> GetListInvitationDoctor()
        {
            try
            {
                var email = User?.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
                var result = await this.workDoctorService.GetInvitationDoctor(email);
                return result;
            }
            catch (ValidationException Ex)
            {
                return BadRequest(Ex.InnerException);
            }
            catch (ServiceException Ex)
            {
                return NotFound(Ex.InnerException);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPatch("PatchStatusServiceWorkDoctor")]
        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Roles = "MEDECIN")]
        public async Task<ActionResult> PatchStatusServiceDoctor([FromBody] UpdateStatusWorkDoctorDto updateStatusWorkDoctorDto)
        {
            try
            {
                var email = User?.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
                await this.workDoctorService.UpdateStatusServiceWorkDoctor(email, updateStatusWorkDoctorDto);
                return Ok();
            }
            catch (ValidationException Ex)
            {
                return BadRequest(Ex.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("GetJobsDoctor")]
        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Roles = "MEDECIN")]
        public async Task<ActionResult<List<JobsDoctorDto>>> GetListJobsDoctor()
        {
            try
            {
                var email = User?.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
                return await this.workDoctorService.GetListJobsDoctorService(email);
            }
            catch (ValidationException Ex)
            {
                return BadRequest(Ex.InnerException);
            }
            catch (ServiceException Ex)
            {
                return BadRequest(Ex.InnerException);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }


    }
}
