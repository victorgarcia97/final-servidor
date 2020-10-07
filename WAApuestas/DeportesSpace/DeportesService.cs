using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WAApuestas.Models;

namespace WAApuestas.DeportesSpace
{
    public class DeportesService : IDeportesService
    {
        private readonly IDeportesRepository _deportesRepository;
        private readonly ILogger<DeportesService> _loggerDeportesService;

        public DeportesService(IDeportesRepository deportesRepository, ILogger<DeportesService> loggerDeportesService)
        {
            _deportesRepository = deportesRepository;
            _loggerDeportesService = loggerDeportesService;
        }

        public async Task<Deporte> GetDeporte(int id)
        {
            var deporte = await _deportesRepository.GetDeporte(id);

            if(deporte == null)
            {
                throw new GestionApuestasException("No se encuentra el deporte con ese id");
            }

            return deporte;
        }

        public async Task<IEnumerable<Deporte>> GetDeportes()
        {
            return await _deportesRepository.GetDeportes();
        }
    }
}
