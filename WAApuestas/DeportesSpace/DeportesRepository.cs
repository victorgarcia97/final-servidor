using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WAApuestas.Models;

namespace WAApuestas.DeportesSpace
{
    public class DeportesRepository: IDeportesRepository
    {
        private readonly GestionApuestasDbContext _context;

        public DeportesRepository(GestionApuestasDbContext context, ILogger<DeportesRepository>logger)
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
