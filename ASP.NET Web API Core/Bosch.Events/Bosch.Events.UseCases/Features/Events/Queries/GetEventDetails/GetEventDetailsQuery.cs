using Bosch.Events.UseCases.DTOs.EventDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQuery:IRequest<EventDto>
    {
        public int EventId { get; set; }
    }
}
