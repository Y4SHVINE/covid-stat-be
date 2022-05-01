using System;
using System.Threading.Tasks;
using CovidStat.Application.DTOs;
using CovidStat.Application.DTOs.SideEffect;
using CovidStat.Application.DTOs.Vaccination;
using CovidStat.Application.DTOs.Travel;
using CovidStat.Application.Filters;
using CovidStat.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidStat.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VaccinationController : ControllerBase
    {
        private readonly IVaccinationService _vaccinationService;

        public VaccinationController(IVaccinationService vaccinationService)
        {
            _vaccinationService = vaccinationService;
        }


        /// <summary>
        /// Returns all vaccinations in the database
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<PaginatedList<GetVaccinationDto>>> GetVaccinationes([FromQuery] GetVaccinationsFilter filter)
        {
            return Ok(await _vaccinationService.GetAllVaccinations(filter));
        }


        /// <summary>
        /// Get one vaccination by Nic from the database
        /// </summary>
        /// <param name="id">The vaccination's ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{nic}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetVaccinationDto), StatusCodes.Status200OK)]
        public ActionResult<GetVaccinationDto> GetVaccinationById(string nic)
        {
            var vaccination = _vaccinationService.GetVaccinationsById(nic);
            if (vaccination == null) return NotFound();
            return Ok(vaccination);
        }

        /// <summary>
        /// Get public vaccinations by Nic from the database
        /// </summary>
        /// <param name="nic">The vaccination's nic</param>
        /// <returns></returns>
        [HttpGet]
        [Route("public/{nic}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetVaccinationDto), StatusCodes.Status200OK)]
        public ActionResult<GetVaccinationDto> GetVaccinationByNICPublic(string nic)
        {
            var vaccination = _vaccinationService.GetVaccinationsById(nic);
            if (vaccination == null) return NotFound();
            return Ok(vaccination);
        }

        /// <summary>
        /// Insert one vaccination in the database
        /// </summary>
        /// <param name="dto">The vaccination information</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GetVaccinationDto>> Create([FromBody] CreateVaccinationDto dto)
        {
            var newVaccination = await _vaccinationService.CreateVaccination(dto);
            return CreatedAtAction(nameof(GetVaccinationById), new { nic = newVaccination.NIC }, newVaccination);

        }

        /// <summary>
        /// Insert sideeffect(s) in the database
        /// </summary>
        /// <param name="dto">The sideEffect information</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("sideeffect/{id}")]
        public async Task<ActionResult<GetTravelDto>> CreateSideEffect(Guid id, [FromBody] CreateSideEffect dto)
        {
            var sideEffects = await _vaccinationService.CreateSideEffect(id, dto);
            return Ok(sideEffects);
        }


        /// <summary>
        /// Update a vaccination from the database
        /// </summary>
        /// <param name="id">The vaccination's ID</param>
        /// <param name="dto">The update object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GetVaccinationDto>> Update(Guid id, [FromBody] UpdateVaccinationDto dto)
        {
            var updatedVaccination = await _vaccinationService.UpdateVaccination(id, dto);

            if (updatedVaccination == null) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Update a sideeffect from the database
        /// </summary>
        /// <param name="id">The sideeffect's ID</param>
        /// <param name="dto">The update object</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route("sideeffect/{id}")]
        public async Task<ActionResult<GetTravelDto>> UpdateSideEffect(Guid id, [FromBody] UpdateSideEffectDto dto)
        {
            var updateTravel = await _vaccinationService.UpdateSideEffect(id, dto);

            if (updateTravel == null) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Delete a vaccination from the database
        /// </summary>
        /// <param name="nic">The vaccination's NIC</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{nic}")]
        public async Task<ActionResult> Delete(string nic)
        {
            var deleted = await _vaccinationService.DeleteVaccination(nic);
            if (deleted) return NoContent();
            return NotFound();
        }


        /// <summary>
        /// Delete a SideEffect from the database
        /// </summary>
        /// <param name="id">The SideEffect's ID</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("sideeffect/{id}")]
        public async Task<ActionResult> DeleteSideEffect(Guid id)
        {
            var deleted = await _vaccinationService.DeleteSideEffect(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
