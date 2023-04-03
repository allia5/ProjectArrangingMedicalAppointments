﻿using DTO;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtripleS.Web.Api.Models.Users.Exceptions;
using Server.Models.Doctor.Exceptions;
using Server.Models.Exceptions;
using Server.Services.Foundation.PlanningAppoimentService;
using System.Security.Claims;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalPlanningController : ControllerBase
    {
        public readonly IPlanningAppoimentService planningAppoimentService;
        public MedicalPlanningController(IPlanningAppoimentService planningAppoimentService)
        {
            this.planningAppoimentService = planningAppoimentService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Roles = "PATIENT")]
        public async Task<ActionResult<AppointmentInformationDto>> PostMedicalPlanningAppoiment(KeysReservationMedicalDto keysReservationMedicalDto)
        {
            try
            {
                var email = User?.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
                return await this.planningAppoimentService.PostNewPlanningAppoimentMedical(email, keysReservationMedicalDto);
            }
            catch (ValidationException Ex)
            {
                return BadRequest(Ex.Message);
            }
            catch (FailedUserServiceException Ex)
            {
                return StatusCode(403);
            }
            catch (ServiceException Ex)
            {
                return NotFound();
            }
            catch (StorageValidationException Ex)
            {
                return Conflict();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

    }
}