using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bosch.Events.Layered.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoschRolesController : ControllerBase
    {
        private readonly ICommonRepository<Role> _rolesRepository;
        private readonly IMapper _mapper;

        public BoschRolesController(ICommonRepository<Role> rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> Get()
        {
            try
            {
                var roles = _mapper.Map<List<RoleDto>>(await _rolesRepository.GetAllAsync());
                if (roles.Count > 0)
                {
                    return Ok(roles);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
