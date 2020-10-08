using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WAApuestas.DeportesSpace;
using WAApuestas.Models;
using WAApuestas.TiposEventoSpace;

namespace WAApuestas.TiposApuestaSpace
{
    public class TiposApuestaService : ITiposApuestaService
    {
        private readonly ITiposApuestaRepository _tiposApuestasRepository;
        private readonly ITiposEventoRepository _tiposEventoRepository;
        private readonly IDeportesRepository _deportesRepository;

        private readonly ILogger<ITiposApuestaService> _logger;

        public TiposApuestaService(ITiposApuestaRepository tiposApuestasRepository, 
                                   ILogger<TiposApuestaService> logger,
                                   ITiposEventoRepository tiposEventoRepository,
                                   IDeportesRepository deportesRepository)
        {
            _tiposApuestasRepository = tiposApuestasRepository;
            _tiposEventoRepository = tiposEventoRepository;
            _deportesRepository = deportesRepository;
            _logger = logger;
        }

        public async Task<TipoApuesta> DeleteTipoApuesta(int id)
        {
            var tipoApuesta = await _tiposApuestasRepository.DeleteTipoApuesta(id);

            if(tipoApuesta == null)
            {
                throw new GestionApuestasException("No se encuentra el tipo de apuesta para borrar");
            }

            return tipoApuesta;
        }

        public async Task<TipoApuesta> GetTipoApuesta(int id)
        {
            var tipoApuesta = await _tiposApuestasRepository.GetTipoApuesta(id);

            if(tipoApuesta == null)
            {
                throw new GestionApuestasException("No se encuentra el tipo de apuesta");
            }
            return tipoApuesta;

        }

        public async Task<IEnumerable<TipoApuesta>> GetTiposApuesta()
        {
            return await _tiposApuestasRepository.GetTiposApuesta();
        }

        public async Task<TipoApuesta> PostTipoApuesta(TipoApuesta tipoApuestas)
        {
            return await _tiposApuestasRepository.PostTipoApuesta(tipoApuestas);
        }

        public async Task<TipoApuesta> PutTipoApuesta(TipoApuesta tipoApuestas)
        {
            return await _tiposApuestasRepository.PutTipoApuesta(tipoApuestas);
        }

        public async Task<IEnumerable<TipoApuesta>> GetTiposApuestasPorDeporte(int tipoEventoId)
        {
            TipoEvento tipoEvento = await _tiposEventoRepository.GetTipoEvento(tipoEventoId);

            if(tipoEvento == null)
            {
                throw new GestionApuestasException("No existe el tipo de evento");
            }

            Deporte deporteTipoEvento = await _deportesRepository.GetDeporte(tipoEvento.DeporteId);

            IEnumerable<TipoApuesta> tiposApuesta = await _tiposApuestasRepository.GetTiposApuesta();

            IEnumerable<TipoApuesta> tiposApuestaPorDeporte = tiposApuesta
                                                                   .Where(d => d.DeporteId == deporteTipoEvento.Id);

            return tiposApuestaPorDeporte;
        }
    }
}
