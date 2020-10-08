using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestaSpace
{
    public class TiposApuestaRepository: ITiposApuestaRepository
    {
        private readonly GestionApuestasDbContext _context;

        public TiposApuestaRepository(GestionApuestasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoApuesta>> GetTiposApuesta()
        {
            return await _context.TiposApuesta
                                    .Include(d => d.Deporte)
                                    .ToListAsync();
        }

        public async Task<TipoApuesta> GetTipoApuesta(int id)
        {
            var tipoApuestas = await _context.TiposApuesta
                                                    .Where(tp => tp.Id == id)
                                                    .Include(d => d.Deporte)
                                                    .FirstOrDefaultAsync();

            if (tipoApuestas == null)
            {
                return null;
            }

            return tipoApuestas;
        }

        public async Task<TipoApuesta> PutTipoApuesta(TipoApuesta tipoApuestas)
        {
            _context.Entry(tipoApuestas).State = EntityState.Modified;
            await _context.SaveChangesAsync();  
            return await this.GetTipoApuesta(tipoApuestas.Id);       
        }

        public async Task<TipoApuesta> PostTipoApuesta(TipoApuesta tipoApuestas)
        {
            _context.TiposApuesta.Add(tipoApuestas);
            await _context.SaveChangesAsync();

            return await this.GetTipoApuesta(tipoApuestas.Id); 
        }

        public async Task<TipoApuesta> DeleteTipoApuesta(int id)
        {
            var tipoApuestas = await this.GetTipoApuesta(id);

            if (tipoApuestas == null)
            {
                return null;
            }

            _context.TiposApuesta.Remove(tipoApuestas);
            await _context.SaveChangesAsync();

            return tipoApuestas;
        }

        public Task<bool> TipoApuestaExists(int id)
        {
            return _context.TiposApuesta.AnyAsync(e => e.Id == id);
        }
    }
}
