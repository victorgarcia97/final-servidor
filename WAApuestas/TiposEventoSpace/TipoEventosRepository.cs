using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAApuestas.Models;

namespace WAApuestas.TiposEventoSpace
{
    public class TiposEventoRepository: ITiposEventoRepository
    {
        private readonly GestionApuestasDbContext _context;
        private readonly ILogger<TiposEventoRepository> _logger;

        public TiposEventoRepository(GestionApuestasDbContext context, ILogger<TiposEventoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<TipoEvento>> GetTiposEvento()
        {
            return await _context.TiposEvento
                                            .Include(d => d.Deporte)
                                            .ToListAsync();
        }

        public async Task<TipoEvento> GetTipoEvento(int id)
        {
            var tipoEvento = await _context.TiposEvento
                                                .Where(te => te.Id == id)
                                                .Include(d => d.Deporte)
                                                .FirstOrDefaultAsync();

            if (tipoEvento == null)
            {
                return null;
            }

            return tipoEvento;
        }

        public async Task PutTipoEvento(TipoEvento tipoEvento)
        {
            _context.Entry(tipoEvento).State = EntityState.Modified;  
            await _context.SaveChangesAsync();
        }

        public async Task<TipoEvento> PostTipoEvento(TipoEvento tipoEvento)
        {
            _context.TiposEvento.Add(tipoEvento);
            await _context.SaveChangesAsync();

            return await this.GetTipoEvento(tipoEvento.Id);
        }

        public async Task<TipoEvento> DeleteTipoEvento(int id)
        {
            var tipoEvento = await _context.TiposEvento
                                                 .Where(te => te.Id == id)
                                                 .Include(d => d.Deporte)
                                                 .FirstOrDefaultAsync();

            if (tipoEvento == null)
            {
                return null;
            }

            _context.TiposEvento.Remove(tipoEvento);
            await _context.SaveChangesAsync();

            return tipoEvento;
        }

        public async Task<bool> TipoEventoExists(int id)
        {
            return await _context.TiposEvento.AnyAsync(e => e.Id == id);
        }
    }
}
