using AutoMapper;
using SalesAPI.DTO;
using SalesAPI.Models;

namespace SalesAPI.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile() 
        {
            CreateMap<EventDto, Event> ();
        }
    }
}
