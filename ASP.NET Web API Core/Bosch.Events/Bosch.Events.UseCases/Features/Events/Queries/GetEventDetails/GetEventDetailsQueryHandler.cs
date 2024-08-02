using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.EventDtos;
using MediatR;

namespace Bosch.Events.UseCases.Features.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, EventDto>
    {
        private readonly ICommonRepository<Event> _eventsRepository;
        private readonly IMapper _mapper;
        public GetEventDetailsQueryHandler(ICommonRepository<Event> eventsRepository, IMapper mapper)
        {
            _eventsRepository = eventsRepository;
            _mapper = mapper;
        }
        public async Task<EventDto> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<EventDto>(await _eventsRepository.GetDetailsAsync(request.EventId));
        }
    }
}
