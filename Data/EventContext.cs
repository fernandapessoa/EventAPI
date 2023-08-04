using Microsoft.EntityFrameworkCore;
using EventAPI.Models;

namespace EventAPI.Data
{
    public class EventContext : DbContext //Contexto que se comunica entre o bd e a api
    {
        public EventContext(DbContextOptions<EventContext> opt) : base (opt)
        {
            
        }

        public DbSet<Event>Events { get; set; }

    }
}
