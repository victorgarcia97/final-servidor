using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestasSpace
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoApuestasController : ControllerBase
    {
        private readonly GestionApuestasDbContext _context;

        public TipoApuestasController(GestionApuestasDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoApuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoApuestas>>> GetTiposApuestas()
        {
            return await _context.TiposApuestas.ToListAsync();
        }

        // GET: api/TipoApuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoApuestas>> GetTipoApuestas(int id)
        {
            var tipoApuestas = await _context.TiposApuestas.FindAsync(id);

            if (tipoApuestas == null)
            {
                return NotFound();
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

            _context.Entry(tipoApuestas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoApuestasExists(id))
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
            _context.TiposApuestas.Add(tipoApuestas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoApuestas", new { id = tipoApuestas.Id }, tipoApuestas);
        }

        // DELETE: api/TipoApuestas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoApuestas>> DeleteTipoApuestas(int id)
        {
            var tipoApuestas = await _context.TiposApuestas.FindAsync(id);
            if (tipoApuestas == null)
            {
                return NotFound();
            }

            _context.TiposApuestas.Remove(tipoApuestas);
            await _context.SaveChangesAsync();

            return tipoApuestas;
        }

        private bool TipoApuestasExists(int id)
        {
            return _context.TiposApuestas.Any(e => e.Id == id);
        }
    }
}
