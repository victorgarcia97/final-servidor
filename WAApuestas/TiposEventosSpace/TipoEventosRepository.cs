using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAApuestas.Models;

namespace WAApuestas.TiposEventosSpace
{
    public class TipoEventosRepository: ITipoEventosRepository
    {
        private readonly GestionApuestasDbContext _context;
        private readonly ILogger<TipoEventosRepository> _logger;

        public TipoEventosRepository(GestionApuestasDbContext context, ILogger<TipoEventosRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<TipoEvento>> GetTiposEventos()
        {
            return await _context.TiposEventos
                                            .Include(d => d.Deporte)
                                            .ToListAsync();
        }

        public async Task<TipoEvento> GetTipoEvento(int id)
        {
            var tipoEvento = await _context.TiposEventos
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
            _context.TiposEventos.Add(tipoEvento);
            await _context.SaveChangesAsync();

            return await this.GetTipoEvento(tipoEvento.Id);
        }

        public async Task<TipoEvento> DeleteTipoEvento(int id)
        {
            var tipoEvento = await _context.TiposEventos
                                                 .Where(te => te.Id == id)
                                                 .Include(d => d.Deporte)
                                                 .FirstOrDefaultAsync();

            if (tipoEvento == null)
            {
                return null;
            }

            _context.TiposEventos.Remove(tipoEvento);
            await _context.SaveChangesAsync();

            return tipoEvento;
        }

        public async Task<bool> TipoEventoExists(int id)
        {
            return await _context.TiposEventos.AnyAsync(e => e.Id == id);
        }
    }
}
