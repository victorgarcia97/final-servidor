using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestaSpace
{
    public class TiposApuestaRepository: ITiposApuestaRepository
    {
        private readonly GestionApuestasDbContext _context;
        private readonly ILogger<TiposApuestaRepository> _logger;

        public TiposApuestaRepository(GestionApuestasDbContext context, ILogger<TiposApuestaRepository>logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<TipoApuesta>> GetTiposApuesta()
        {
            _logger.LogInformation($"Tipo Apuesta repository: get tipos apuesta");
            return await _context.TiposApuesta
                                    .Include(d => d.Deporte)
                                    .ToListAsync();
        }

        public async Task<TipoApuesta> GetTipoApuesta(int id)
        {
            _logger.LogInformation($"Tipo Apuesta repository: get tipos apuesta by id {id}");
            var tipoApuestas = await _context.TiposApuesta
                                                    .Where(tp => tp.Id == id)
                                                    .Include(d => d.Deporte)
                                                    .FirstOrDefaultAsync();

            if (tipoApuestas == null)
            {
                _logger.LogInformation($"Tipo Apuesta repository: get tipos apuesta by id {id} no existe");
                return null;
            }

            _logger.LogInformation($"Tipo Apuesta repository: get tipos apuesta by id {id} correcto");
            return tipoApuestas;
        }

        public async Task<TipoApuesta> PutTipoApuesta(TipoApuesta tipoApuestas)
        {
            _context.Entry(tipoApuestas).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Tipo Apuesta repository: put {tipoApuestas.Id} correcto");
            return await this.GetTipoApuesta(tipoApuestas.Id);       
        }

        public async Task<TipoApuesta> PostTipoApuesta(TipoApuesta tipoApuestas)
        {
            _context.TiposApuesta.Add(tipoApuestas);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Tipo Apuesta repository: post {tipoApuestas.Id} correcto");
            return await this.GetTipoApuesta(tipoApuestas.Id); 
        }

        public async Task<TipoApuesta> DeleteTipoApuesta(int id)
        {
            _logger.LogInformation($"Tipo Apuesta repository: delete, busca tipo apuesta id {id}");
            var tipoApuestas = await this.GetTipoApuesta(id);

            if (tipoApuestas == null)
            {
                _logger.LogInformation($"Tipo Apuesta repository: delete, busca tipo apuesta id {id} no existe");
                return null;
            }

            _context.TiposApuesta.Remove(tipoApuestas);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Tipo Apuesta repository: delete tipo apuesta id {id} correcto");
            return tipoApuestas;
        }

        public Task<bool> TipoApuestaExists(int id)
        {
            return _context.TiposApuesta.AnyAsync(e => e.Id == id);
        }
    }
}
