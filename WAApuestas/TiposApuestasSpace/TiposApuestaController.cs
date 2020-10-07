using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestaSpace
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposApuestaController : ControllerBase, ITiposApuestaController
    {
        private readonly ITiposApuestaService _tiposApuestasService;
        public TiposApuestaController(ITiposApuestaService tiposApuestasService)
        {
            _tiposApuestasService = tiposApuestasService;
        }

        // GET: api/TipoApuestas
        [HttpGet]
        public async Task<IEnumerable<TipoApuestas>> GetTiposApuesta()
        {
            return await _tiposApuestasService.GetTiposApuesta();
        }

        // GET: api/TipoApuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoApuestas>> GetTipoApuesta(int id)
        {
            TipoApuestas tipoApuestas;
            try {
                tipoApuestas = await _tiposApuestasService.GetTipoApuesta(id);
            }
            catch (GestionApuestasException e)
            {
                return NotFound(e.Message);
            }

            return tipoApuestas;
        }

        // PUT: api/TipoApuestas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoApuesta(int id, TipoApuestas tipoApuestas)
        {
            if (id != tipoApuestas.Id)
            {
                return BadRequest();
            }


            try
            {
                await _tiposApuestasService.PutTipoApuesta(tipoApuestas);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! _tiposApuestasService.GetTiposApuesta().Result.Any(e => e.Id == id))
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

        // POST: api/TipoApuestas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoApuestas>> PostTipoApuesta(TipoApuestas tipoApuestas)
        {
            var tipoApuesta = await _tiposApuestasService.PostTipoApuesta(tipoApuestas);

            return CreatedAtAction("GetTipoApuestas", new { id = tipoApuesta.Id }, tipoApuesta);
        }

        // DELETE: api/TipoApuestas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoApuestas>> DeleteTipoApuesta(int id)
        {
            TipoApuestas tipoApuestas;
            try
            {
                tipoApuestas = await _tiposApuestasService.DeleteTipoApuesta(id);
            }
            catch (GestionApuestasException e)
            {
                return NotFound(e.Message);
            }

            return tipoApuestas;
        }
    }
}
