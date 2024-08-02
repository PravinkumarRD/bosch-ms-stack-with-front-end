using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.EventDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Events.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, List<EventDto>>
    {
        private readonly ICommonRepository<Event> _eventsRepository;
        private readonly IMapper _mapper;
        public GetAllEventsQueryHandler(ICommonRepository<Event> eventsRepository, IMapper mapper)
        {
            _eventsRepository = eventsRepository;
            _mapper = mapper;
        }

        public async Task<List<EventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<EventDto>>(await _eventsRepository.GetAllAsync());
        }
    }
}
