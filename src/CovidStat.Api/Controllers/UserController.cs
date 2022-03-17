using System;
using System.Threading.Tasks;
using CovidStat.Application.DTOs;
using CovidStat.Application.DTOs.Auth;
using CovidStat.Application.DTOs.User;
using CovidStat.Application.Filters;
using CovidStat.Application.Interfaces;
using CovidStat.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ISession = CovidStat.Domain.Auth.Interfaces.ISession;

namespace CovidStat.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly ISession _session;

        public UserController(IUserService userService, IAuthService authService, ISession session)
        {
            _userService = userService;
            _authService = authService;
            _session = session;
        }

        /// <summary>
        /// Authenticates the user and returns the token information.
        /// </summary>
        /// <param name="loginInfo">Email and password information</param>
        /// <returns>Token information</returns>
        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(JwtDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto loginInfo)
        {
            var user = await _userService.Authenticate(loginInfo.Email, loginInfo.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(_authService.GenerateToken(user));
        }


        /// <summary>
        /// Returns all users in the database
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(PaginatedList<GetUserDto>), StatusCodes.Status200OK)]
        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetUserDto>>> GetUsers([FromQuery] GetUsersFilter filter)
        {
            return Ok(await _userService.GetAllUsers(filter));
        }


        /// <summary>
        /// Get one user by id from the database
        /// </summary>
        /// <param name="id">The user's ID</param>
        /// <returns></returns>
        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetUserDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetUserDto>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<GetUserDto>> CreateUser(CreateUserDto dto)
        {
            var newAccount = await _userService.CreateUser(dto);
            return CreatedAtAction(nameof(GetUserById), new { id = newAccount.Id }, newAccount);
        }

        [HttpPatch("updatePassword")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdatePassword([FromBody] UpdatePasswordDto dto)
        {
            await _userService.UpdatePassword(_session.UserId, dto);
            return NoContent();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var deleted = await _userService.DeleteUser(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
