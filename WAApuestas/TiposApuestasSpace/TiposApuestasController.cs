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
    public class TiposApuestasController : ControllerBase
    {
        private readonly ITiposApuestasService _tiposApuestasService;
        public TiposApuestasController(ITiposApuestasService tiposApuestasService)
        {
            _tiposApuestasService = tiposApuestasService;
        }

        // GET: api/TipoApuestas
        [HttpGet]
        public async Task<IEnumerable<TipoApuestas>> GetTiposApuestas()
        {
            return await _tiposApuestasService.GetTiposApuestas();
        }

        // GET: api/TipoApuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoApuestas>> GetTipoApuestas(int id)
        {
            TipoApuestas tipoApuestas;
            try {
                tipoApuestas = await _tiposApuestasService.GetTipoApuestas(id);
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
        public async Task<IActionResult> PutTipoApuestas(int id, TipoApuestas tipoApuestas)
        {
            if (id != tipoApuestas.Id)
            {
                return BadRequest();
            }


            try
            {
                await _tiposApuestasService.PutTipoApuestas(tipoApuestas);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! _tiposApuestasService.GetTiposApuestas().Result.Any(e => e.Id == id))
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
        public async Task<ActionResult<TipoApuestas>> PostTipoApuestas(TipoApuestas tipoApuestas)
        {
            var tipoApuesta = await _tiposApuestasService.PostTipoApuestas(tipoApuestas);

            return CreatedAtAction("GetTipoApuestas", new { id = tipoApuesta.Id }, tipoApuesta);
        }

        // DELETE: api/TipoApuestas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoApuestas>> DeleteTipoApuestas(int id)
        {
            TipoApuestas tipoApuestas;
            try
            {
                tipoApuestas = await _tiposApuestasService.DeleteTipoApuestas(id);
            }
            catch (GestionApuestasException e)
            {
                return NotFound(e.Message);
            }

            return tipoApuestas;
        }
    }
}
