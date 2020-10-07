using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestaSpace
{
    public class TiposApuestaService : ITiposApuestaService
    {
        private readonly ITiposApuestaRepository _tiposApuestasRepository;
        private readonly ILogger<ITiposApuestaService> _logger;

        public TiposApuestaService(ITiposApuestaRepository tiposApuestasRepository, ILogger<TiposApuestaService> logger)
        {
            _tiposApuestasRepository = tiposApuestasRepository;
            _logger = logger;
        }

        public async Task<TipoApuestas> DeleteTipoApuesta(int id)
        {
            var tipoApuesta = await _tiposApuestasRepository.DeleteTipoApuesta(id);

            if(tipoApuesta == null)
            {
                throw new GestionApuestasException("No se encuentra el tipo de apuesta para borrar");
            }

            return tipoApuesta;
        }

        public async Task<TipoApuestas> GetTipoApuesta(int id)
        {
            var tipoApuesta = await _tiposApuestasRepository.GetTipoApuesta(id);

            if(tipoApuesta == null)
            {
                throw new GestionApuestasException("No se encuentra el tipo de apuesta");
            }
            return tipoApuesta;

        }

        public async Task<IEnumerable<TipoApuestas>> GetTiposApuesta()
        {
            return await _tiposApuestasRepository.GetTiposApuesta();
        }

        public async Task<TipoApuestas> PostTipoApuesta(TipoApuestas tipoApuestas)
        {
            return await _tiposApuestasRepository.PostTipoApuesta(tipoApuestas);
        }

        public async Task PutTipoApuesta(TipoApuestas tipoApuestas)
        {
            await _tiposApuestasRepository.PutTipoApuesta(tipoApuestas);
        }
    }
}
