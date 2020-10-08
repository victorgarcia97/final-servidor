using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAApuestas.Dtos;
using WAApuestas.Models;

namespace WAApuestas.EventosSpace
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase, IEventosController
    {
        private readonly IEventosService _eventosService;

        public EventosController(IEventosService eventosService)
        {
            _eventosService = eventosService;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<IEnumerable<EventoDto>> GetEventos()
        {
            IEnumerable<Evento> eventos = await _eventosService.GetEventos();
            IList<EventoDto> dtos = new List<EventoDto>();

            foreach(Evento e in eventos)
            {
                dtos.Add(EventoDto2Evento.Model2Dto(e));
            }

            return dtos;
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoDto>> GetEvento(int id)
        {
            Evento evento;

            try
            {
                evento = await _eventosService.GetEvento(id);
            }
            catch (GestionApuestasException e)
            {
                return NotFound(e.Message);
            }

            return EventoDto2Evento.Model2Dto(evento);
        }

        // PUT: api/Eventos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<EventoDto>> PutEvento(int id, EventoDto evento)
        {

            Evento eventoModificado;

            if (id != evento.Id)
            {
                return BadRequest();
            }

            try
            {
                eventoModificado = await _eventosService.PutEvento(EventoDto2Evento.Dto2Model(evento));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_eventosService.GetEventos().Result.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return EventoDto2Evento.Model2Dto(eventoModificado);
        }

        // POST: api/Eventos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventoDto>> PostEvento(EventoDto evento)
        {
            var ev = await _eventosService.PostEvento(EventoDto2Evento.Dto2Model(evento));

            return CreatedAtAction("GetEvento", new { id = ev.Id }, EventoDto2Evento.Model2Dto(ev));
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventoDto>> DeleteEvento(int id)
        {
            Evento evento;

            try
            {
                evento = await _eventosService.DeleteEvento(id);
            }
            catch (GestionApuestasException e)
            {
                return NotFound(e.Message);
            }

            return EventoDto2Evento.Model2Dto(evento);
        }
    }
}
