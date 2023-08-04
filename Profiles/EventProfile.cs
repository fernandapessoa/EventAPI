using AutoMapper;
using EventAPI.DTO;
using EventAPI.Models;

namespace EventAPI.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile() 
        {
            CreateMap<EventDto, Event> ();
        }
    }
}
