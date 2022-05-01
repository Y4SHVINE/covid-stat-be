using System;
using System.Threading.Tasks;
using CovidStat.Application.DTOs;
using CovidStat.Application.DTOs.Profile;
using CovidStat.Application.DTOs.Travel;
using CovidStat.Application.Filters;
using CovidStat.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidStat.Api.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }


        /// <summary>
        /// Returns all profiles in the database
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetProfileDto>>> GetProfilees([FromQuery] GetProfilesFilter filter)
        {
            return Ok(await _profileService.GetAllProfiles(filter));
        }


        /// <summary>
        /// Get one profile by id from the database
        /// </summary>
        /// <param name="id">The profile's ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{nic}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetProfileDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetProfileDto>> GetProfileById(string nic)
        {
            var profile = await _profileService.GetProfileById(nic);
            if (profile == null) return NotFound();
            return Ok(profile);
        }

        /// <summary>
        /// Insert one profile in the database
        /// </summary>
        /// <param name="dto">The profile information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GetProfileDto>> Create([FromBody] CreateProfileDto dto)
        {
            var newProfile = await _profileService.CreateProfile(dto);
            return CreatedAtAction(nameof(GetProfileById), new { nic = newProfile.NIC }, newProfile);

        }

        /// <summary>
        /// Insert travel(s) in the database
        /// </summary>
        /// <param name="dto">The travel information</param>
        /// <returns></returns>
        [HttpPost]
        [Route("travel/{nic}")]
        public async Task<ActionResult<GetTravelDto>> CreateTravel(string nic, [FromBody] CreateTravelDto dto)
        {
            var newTravel = await _profileService.CreateTravelProfile(nic, dto);
            return Ok(newTravel);
        }

        /// <summary>
        /// Update a profile from the database
        /// </summary>
        /// <param name="nic">The profile's ID</param>
        /// <param name="dto">The update object</param>
        /// <returns></returns>
        [HttpPut("{nic}")]
        public async Task<ActionResult<GetProfileDto>> Update(string nic, [FromBody] UpdateProfileDto dto)
        {
            var updatedProfile = await _profileService.UpdateProfile(nic, dto);

            if (updatedProfile == null) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Update a travel from the database
        /// </summary>
        /// <param name="id">The travel's ID</param>
        /// <param name="dto">The update object</param>
        /// <returns></returns>
        [HttpPut]
        [Route("travel/{id}")]
        public async Task<ActionResult<GetTravelDto>> UpdateTravel(Guid id, [FromBody] UpdateTravelDto dto)
        {
            var updateTravel = await _profileService.UpdateTravel(id, dto);

            if (updateTravel == null) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Delete a profile from the database
        /// </summary>
        /// <param name="nic">The profile's NIC</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{nic}")]
        public async Task<ActionResult> Delete(string nic)
        {
            var deleted = await _profileService.DeleteProfile(nic);
            if (deleted) return NoContent();
            return NotFound();
        }

        /// <summary>
        /// Delete a profile from the database
        /// </summary>
        /// <param name="id">The travel's ID</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("travel/{id}")]
        public async Task<ActionResult> DeleteTravel(Guid id)
        {
            var deleted = await _profileService.DeleteTravel(id);
            if (deleted) return NoContent();
            return NotFound();
        }

    }
}
