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
        public async Task<IEnumerable<TipoApuesta>> GetTiposApuesta()
        {
            return await _tiposApuestasService.GetTiposApuesta();
        }

        // GET: api/TipoApuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoApuesta>> GetTipoApuesta(int id)
        {
            TipoApuesta tipoApuestas;
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
        public async Task<ActionResult<TipoApuesta>> PutTipoApuesta(int id, TipoApuesta tipoApuestas)
        {
            TipoApuesta tp;

            if (id != tipoApuestas.Id)
            {
                return BadRequest();
            }


            try
            {
                tp = await _tiposApuestasService.PutTipoApuesta(tipoApuestas);
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

            return tp;
        }

        // POST: api/TipoApuestas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoApuesta>> PostTipoApuesta(TipoApuesta tipoApuestas)
        {
            var tipoApuesta = await _tiposApuestasService.PostTipoApuesta(tipoApuestas);

            return CreatedAtAction("GetTipoApuestas", new { id = tipoApuesta.Id }, tipoApuesta);
        }

        // DELETE: api/TipoApuestas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoApuesta>> DeleteTipoApuesta(int id)
        {
            TipoApuesta tipoApuestas;
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

        [HttpGet("PorDeporte/{tipoEventoId}")]
        public async Task<ActionResult<IEnumerable<TipoApuesta>>> GetTiposApuestasPorDeporte(int tipoEventoId)
        {
            IEnumerable<TipoApuesta> lista;
            try
            {
                lista = await _tiposApuestasService.GetTiposApuestasPorDeporte(tipoEventoId);

            }
            catch(GestionApuestasException e)
            {
                return NotFound(e.Message);
            }

            return  Accepted(lista);
        }
    }
}
