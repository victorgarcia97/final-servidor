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
            _logger.LogInformation($"Tipo Eventos Repository: get correcto");

            return await _context.TiposEvento
                                            .Include(d => d.Deporte)
                                            .ToListAsync();
        }

        public async Task<TipoEvento> GetTipoEvento(int id)
        {
            _logger.LogInformation($"Tipo Eventos Repository: get by id {id} busca");

            var tipoEvento = await _context.TiposEvento
                                                .Where(te => te.Id == id)
                                                .Include(d => d.Deporte)
                                                .FirstOrDefaultAsync();

            if (tipoEvento == null)
            {
                _logger.LogInformation($"Tipo Eventos Repository: get by id {id} no existe");
                return null;
            }

            _logger.LogInformation($"Tipo Eventos Repository: get by id {id} correcto");
            return tipoEvento;
        }

        public async Task<TipoEvento> PutTipoEvento(TipoEvento tipoEvento)
        {
            _context.Entry(tipoEvento).State = EntityState.Modified;  
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Tipo Eventos Repository: put {tipoEvento.Id} correcto");
            return await this.GetTipoEvento(tipoEvento.Id);
        }

        public async Task<TipoEvento> PostTipoEvento(TipoEvento tipoEvento)
        {
            _context.TiposEvento.Add(tipoEvento);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Tipo Eventos Repository: post {tipoEvento.Id} correcto");
            return await this.GetTipoEvento(tipoEvento.Id);
        }

        public async Task<TipoEvento> DeleteTipoEvento(int id)
        {
            _logger.LogInformation($"Tipo Eventos Repository: delete {id} busca");

            var tipoEvento = await _context.TiposEvento
                                                 .Where(te => te.Id == id)
                                                 .Include(d => d.Deporte)
                                                 .FirstOrDefaultAsync();

            if (tipoEvento == null)
            {
                _logger.LogInformation($"Tipo Eventos Repository: delete {id} no existe");
                return null;
            }

            _context.TiposEvento.Remove(tipoEvento);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Tipo Eventos Repository: delete {id} correcot");
            return tipoEvento;
        }

        public async Task<bool> TipoEventoExists(int id)
        {
            return await _context.TiposEvento.AnyAsync(e => e.Id == id);
        }
    }
}
