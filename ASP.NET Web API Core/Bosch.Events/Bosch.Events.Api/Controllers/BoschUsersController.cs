using Bosch.Events.Api.Jwt;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.DTOs.UserDtos;
using Bosch.Events.UseCases.Features.Roles.Queries.GetRoleDetails;
using Bosch.Events.UseCases.Features.Users.Commands.CreateUser;
using Bosch.Events.UseCases.Features.Users.Queries.AuthenticateUser;
using Bosch.Events.UseCases.Features.Users.Queries.GetAllUsers;
using Bosch.Events.UseCases.Features.Users.Queries.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Bosch.Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class BoschUsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenManager _tokenManager;
        public BoschUsersController(IMediator mediator, ITokenManager tokenManager)
        {
            _mediator = mediator;
            _tokenManager = tokenManager;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            try
            {
                var users = await _mediator.Send(new GetAllUsersQuery());
                if (users.Count > 0)
                {
                    return Ok(users);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetDetails(int id)
        {
            try
            {
                var role = await _mediator.Send(new GetUserDetailsQuery() { UserId = id });
                if (role == null)
                {
                    return NotFound(new { Message = $"Sorry! No Role Found with Id {id}!" });
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post(InsertUserDto user)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = hashedPassword;
                int result = await _mediator.Send(new CreateUserCommand() { User = user });
                if (result > 0)
                {
                    return Created("GetDetails", user);
                }
            }
            return BadRequest(new { Message = "User Creation Failed! Please retry!" });
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Credentials")]
        public async Task<ActionResult<UserDto>> CheckCerndentialsPost(UserDto user)
        {
            if (ModelState.IsValid)
            {
                UserDto result = await _mediator.Send(new AuthenticateUserQuery() { Credentials = user });
                if (result != null)
                {
                    var passwordVerification = BCrypt.Net.BCrypt.Verify(user.Password, result.Password);
                    if (!passwordVerification)
                    {
                        return BadRequest(new { Message = "Please check your password!" });
                    }
                    var role = await _mediator.Send(new GetRoleDetailsQuery() { RoleId = result.RoleId });
                    if (role == null)
                    {
                        return NotFound(new { Message = $"Sorry! No Role Found!" });
                    }
                    return Ok(new AuthResponse() { Email = result.UserName, Role = role.RoleName, Success = true, token = _tokenManager.GenerateToken(result, role.RoleName) });
                }
                else
                {
                    return BadRequest(new { Message = $"User with email/name {user.UserName} does not exist!" });
                }
            }
            return BadRequest(new { Message = "Authentication Failed!!!" });
        }
    }
}
