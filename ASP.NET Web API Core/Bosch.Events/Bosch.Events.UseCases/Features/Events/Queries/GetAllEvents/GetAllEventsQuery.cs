using Bosch.Events.UseCases.DTOs.EventDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Events.Queries.GetAllEvents
{
    public class GetAllEventsQuery:IRequest<List<EventDto>>
    {
    }
}
