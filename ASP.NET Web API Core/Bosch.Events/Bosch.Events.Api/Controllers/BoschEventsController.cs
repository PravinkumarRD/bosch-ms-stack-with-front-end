using Bosch.Events.UseCases.DTOs.EventDtos;
using Bosch.Events.UseCases.Features.Events.Queries.GetAllEvents;
using Bosch.Events.UseCases.Features.Events.Queries.GetEventDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Bosch.Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors]
    public class BoschEventsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BoschEventsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<List<EventDto>>> Get()
        {
            try
            {
                var events = await _mediator.Send(new GetAllEventsQuery());
                if (events == null || events.Count == 0)
                {
                    return NotFound(new { Message = "Sorry! No Events Found!" });
                }
                return Ok(events);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EventDto>> GetDetails(int id)
        {
            try
            {
                var @event = await _mediator.Send(new GetEventDetailsQuery() { EventId = id });
                if (@event == null)
                {
                    return NotFound(new { Message = $"Sorry! No Event Found with Id {id}!" });
                }
                return Ok(@event);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
