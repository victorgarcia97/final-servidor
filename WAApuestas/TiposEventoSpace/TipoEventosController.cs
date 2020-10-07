using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAApuestas.Models;

namespace WAApuestas.TiposEventoSpace
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposEventoController : ControllerBase
    {
        private readonly ITiposEventoService _tipoEventosService;

        public TiposEventoController(ITiposEventoService tipoEventosService)
        {
            _tipoEventosService = tipoEventosService;
        }

        // GET: api/TipoEventos
        [HttpGet]
        public async Task<IEnumerable<TipoEvento>> GetTiposEventos()
        {
            return await _tipoEventosService.GetTiposEvento();
        }

        // GET: api/TipoEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEvento>> GetTipoEvento(int id)
        {
            TipoEvento tipoEvento;

            try
            {
                tipoEvento = await _tipoEventosService.GetTipoEvento(id);
            }
            catch (GestionApuestasException e)
            {
                return NotFound(e.Message);
            }

            return tipoEvento;
        }

        // PUT: api/TipoEventos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEvento(int id, TipoEvento tipoEvento)
        {
            if (id != tipoEvento.Id)
            {
                return BadRequest();
            }

            try
            {
                await _tipoEventosService.PutTipoEvento(tipoEvento);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_tipoEventosService.GetTiposEvento().Result.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoEventos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoEvento>> PostTipoEvento(TipoEvento tipoEvento)
        {
            var tipo = await _tipoEventosService.PostTipoEvento(tipoEvento);

            return CreatedAtAction("PostTipoEvento", tipo);
        }

        // DELETE: api/TipoEventos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoEvento>> DeleteTipoEvento(int id)
        {
            TipoEvento tipoEvento;

            try
            {
                tipoEvento = await _tipoEventosService.DeleteTipoEvento(id);
            }
            catch (GestionApuestasException e)
            {
                return NotFound(e.Message);
            }

            return tipoEvento;
        }
    }
}
