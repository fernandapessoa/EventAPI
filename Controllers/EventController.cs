using EventAPI.Models;
using Microsoft.AspNetCore.Mvc;
using EventAPI.Data;
using EventAPI.DTO;
using AutoMapper;

namespace EventAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] //aqui é a rota. Passando o [controller] se refere a EventController
    public class EventController : ControllerBase //está extendendo da classe ControllerBase
    {
        private EventContext _context;
        private IMapper _mapper;


        public EventController(EventContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //função para registrar evento
        [HttpPost] //definindo ser POST
        public IActionResult RegisterEvent([FromBody] EventDto newEvent)
        {
            Event @event = _mapper.Map<Event>(newEvent);

           

            _context.Events.Add(@event);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEventbyId), new { Id = @event.Id }, @event);
        }

        [HttpGet]
        public IEnumerable<Event> GetEvent()
        {
            return _context.Events;
        }

        [HttpGet("{id}")] //recebe um id por param
        public IActionResult GetEventbyId(int id) //o ? diz que talvez retorne nulo
        {
            Event? @event = _context.Events.FirstOrDefault(e => e.Id == id);
            if(@event != null)
            {
                return Ok(@event);
            }
            return NotFound($"status: Fail.\nEvent of id '{id}' not found.");
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, [FromBody] EventDto updtedEvent)
        {
            Event @event = _context.Events.FirstOrDefault(e => e.Id == id);
            if(@event == null)
            {
                return NotFound();
            }
            _mapper.Map(UpdateEvent, @event);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            Event @event = _context.Events.FirstOrDefault(e => e.Id == id);
            if (@event == null)
            {
                return NotFound();
            }
            _context.Events.Remove(@event);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
