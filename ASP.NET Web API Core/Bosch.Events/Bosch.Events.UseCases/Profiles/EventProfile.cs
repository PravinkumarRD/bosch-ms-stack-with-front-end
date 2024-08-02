using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.UseCases.DTOs.EventDtos;

namespace Bosch.Events.UseCases.Profiles
{
    public class EventProfile:Profile
    {
        public EventProfile()
        {
            CreateMap<Event,EventDto>();
            CreateMap<InsertEventDto, Event>();
        }
    }
}
