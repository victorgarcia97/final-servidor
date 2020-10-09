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

            _logger.LogInformation($"Tipo Apuesta Service: delete {id} busca");
            var tipoApuesta = await _tiposApuestasRepository.DeleteTipoApuesta(id);

            if(tipoApuesta == null)
            {
                _logger.LogInformation($"Tipo Apuesta Service: delete {id} no existe");
                throw new GestionApuestasException("No se encuentra el tipo de apuesta para borrar");
            }

            _logger.LogInformation($"Tipo Apuesta Service: delete {id} correcto");
            return tipoApuesta;
        }

        public async Task<TipoApuesta> GetTipoApuesta(int id)
        {
            _logger.LogInformation($"Tipo Apuesta Service: get by id {id} busca");

            var tipoApuesta = await _tiposApuestasRepository.GetTipoApuesta(id);

            if(tipoApuesta == null)
            {
                _logger.LogInformation($"Tipo Apuesta Service: get by id {id} no existe");
                throw new GestionApuestasException("No se encuentra el tipo de apuesta");
            }
            _logger.LogInformation($"Tipo Apuesta Service: get by id {id} correcto");
            return tipoApuesta;

        }

        public async Task<IEnumerable<TipoApuesta>> GetTiposApuesta()
        {
            _logger.LogInformation($"Tipo Apuesta Service: get");
            return await _tiposApuestasRepository.GetTiposApuesta();
        }

        public async Task<TipoApuesta> PostTipoApuesta(TipoApuesta tipoApuestas)
        {
            _logger.LogInformation($"Tipo Apuesta Service: post");
            return await _tiposApuestasRepository.PostTipoApuesta(tipoApuestas);
        }

        public async Task<TipoApuesta> PutTipoApuesta(TipoApuesta tipoApuestas)
        {
            _logger.LogInformation($"Tipo Apuesta Service: put");
            return await _tiposApuestasRepository.PutTipoApuesta(tipoApuestas);
        }

        public async Task<IEnumerable<TipoApuesta>> GetTiposApuestasPorDeporte(int tipoEventoId)
        {
            _logger.LogInformation($"Tipo Apuesta Service: get tipos apuesta por deporte busca tipos de evento");

            TipoEvento tipoEvento = await _tiposEventoRepository.GetTipoEvento(tipoEventoId);

            if(tipoEvento == null)
            {
                _logger.LogInformation($"Tipo Apuesta Service: get tipos apuesta por deporte get tipos de evento no existe con id {tipoEventoId}");
                throw new GestionApuestasException("No existe el tipo de evento");
            }


            _logger.LogInformation($"Tipo Apuesta Service: get tipos apuesta por deporte get deporte");
            Deporte deporteTipoEvento = await _deportesRepository.GetDeporte(tipoEvento.DeporteId);

            _logger.LogInformation($"Tipo Apuesta Service: get tipos apuesta por deporte get tipos apuesta");
            IEnumerable<TipoApuesta> tiposApuesta = await _tiposApuestasRepository.GetTiposApuesta();

            IEnumerable<TipoApuesta> tiposApuestaPorDeporte = tiposApuesta
                                                                   .Where(d => d.DeporteId == deporteTipoEvento.Id);

            _logger.LogInformation($"Tipo Apuesta Service: get tipos apuesta por deporte retorna tipos de apuesta por deporte");
            return tiposApuestaPorDeporte;
        }
    }
}
