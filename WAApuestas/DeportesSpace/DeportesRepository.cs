using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WAApuestas.Models;

namespace WAApuestas.DeportesSpace
{
    public class DeportesRepository: IDeportesRepository
    {
        private readonly GestionApuestasDbContext _context;

        public DeportesRepository(GestionApuestasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Deporte>> GetDeportes()
        {
            return await _context.Deportes.ToListAsync();
        }

        public async Task<Deporte> GetDeporte(int id)
        {
            var deporte = await _context.Deportes.FindAsync(id);

            if (deporte == null)
            {
                return null;
            }

            return deporte;
        }
    }
}
