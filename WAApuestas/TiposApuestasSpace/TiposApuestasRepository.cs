using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestasSpace
{
    public class TiposApuestasRepository: ITiposApuestasRepository
    {
        private readonly GestionApuestasDbContext _context;

        public TiposApuestasRepository(GestionApuestasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoApuestas>> GetTiposApuestas()
        {
            return await _context.TiposApuesta
                                    .Include(d => d.Deporte)
                                    .ToListAsync();
        }

        public async Task<TipoApuestas> GetTipoApuestas(int id)
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

        public async Task PutTipoApuestas(TipoApuestas tipoApuestas)
        {
            _context.Entry(tipoApuestas).State = EntityState.Modified;
            await _context.SaveChangesAsync();         
        }

        public async Task<TipoApuestas> PostTipoApuestas(TipoApuestas tipoApuestas)
        {
            _context.TiposApuesta.Add(tipoApuestas);
            await _context.SaveChangesAsync();

            return tipoApuestas;
        }

        public async Task<TipoApuestas> DeleteTipoApuestas(int id)
        {
            var tipoApuestas = await this.GetTipoApuestas(id);

            if (tipoApuestas == null)
            {
                return null;
            }

            _context.TiposApuesta.Remove(tipoApuestas);
            await _context.SaveChangesAsync();

            return tipoApuestas;
        }

        public Task<bool> TipoApuestasExists(int id)
        {
            return _context.TiposApuesta.AnyAsync(e => e.Id == id);
        }
    }
}
