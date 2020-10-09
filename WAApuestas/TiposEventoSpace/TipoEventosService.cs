using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WAApuestas.Models;

namespace WAApuestas.TiposEventoSpace
{
    public class TiposEventoService : ITiposEventoService
    {
        private readonly ITiposEventoRepository _tipoEventosRepository;
        private readonly ILogger<ITiposEventoService> _logger;

        public TiposEventoService(ITiposEventoRepository tipoEventosRepository, ILogger<TiposEventoService> logger)
        {
            _tipoEventosRepository = tipoEventosRepository;
            _logger = logger;
        }

        public async Task<TipoEvento> DeleteTipoEvento(int id)
        {
            _logger.LogInformation($"Tipo Eventos Service: Delete {id}");

            var tipoEvento = await _tipoEventosRepository.DeleteTipoEvento(id);

            if(tipoEvento == null)
            {
                _logger.LogInformation($"Tipo Eventos Service: Delete No existe {id}");
                throw new GestionApuestasException("No se encuentra el tipo de evento para borrar");
            }

            _logger.LogInformation($"Tipo Eventos Service: Delete correcto, devuelve {id}");
            return tipoEvento;
        }

        public async Task<TipoEvento> GetTipoEvento(int id)
        {
            _logger.LogInformation($"Tipo Eventos Service: Get by id {id}");
            var tipoEvento = await _tipoEventosRepository.GetTipoEvento(id);


            if(tipoEvento == null)
            {
                _logger.LogInformation($"Tipo Eventos Service: Get by id {id} no existe");
                throw new GestionApuestasException("No se encuentra el tipo de evento");
            }


            _logger.LogInformation($"Tipo Eventos Service: Get by id {id} correcto");
            return tipoEvento;
        }

        public async Task<IEnumerable<TipoEvento>> GetTiposEvento()
        {
            _logger.LogInformation($"Tipo Eventos Service: Get correcto");
            return await _tipoEventosRepository.GetTiposEvento();
        }

        public async Task<TipoEvento> PostTipoEvento(TipoEvento tipoEvento)
        {
            _logger.LogInformation($"Tipo Eventos Service: post {tipoEvento.Id} correcto");
            return await _tipoEventosRepository.PostTipoEvento(tipoEvento);
        }

        public async Task<TipoEvento>  PutTipoEvento(TipoEvento tipoEvento)
        {
            _logger.LogInformation($"Tipo Eventos Service: put {tipoEvento.Id} correcto");
            return await  _tipoEventosRepository.PutTipoEvento(tipoEvento);
        }
    }
}

