using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WAApuestas.Models;

namespace WAApuestas.TiposEventosSpace
{
    public class TipoEventosService : ITipoEventosService
    {
        private readonly ITipoEventosRepository _tipoEventosRepository;
        private readonly ILogger<ITipoEventosService> _loggerService;

        public TipoEventosService(ITipoEventosRepository tipoEventosRepository, ILogger<TipoEventosService> loggerService)
        {
            _tipoEventosRepository = tipoEventosRepository;
            _loggerService = loggerService;
        }

        public async Task<TipoEvento> DeleteTipoEvento(int id)
        {
            var tipoEvento = await _tipoEventosRepository.DeleteTipoEvento(id);

            if(tipoEvento == null)
            {
                throw new GestionApuestasException("No se encuentra el tipo de evento para borrar");
            }

            return tipoEvento;
        }

        public async Task<TipoEvento> GetTipoEvento(int id)
        {
            var tipoEvento = await _tipoEventosRepository.GetTipoEvento(id);

            if(tipoEvento == null)
            {
                throw new GestionApuestasException("No se encuentra el tipo de evento");
            }

            return tipoEvento;
        }

        public async Task<IEnumerable<TipoEvento>> GetTiposEventos()
        {
            return await _tipoEventosRepository.GetTiposEventos();
        }

        public async Task<TipoEvento> PostTipoEvento(TipoEvento tipoEvento)
        {
            return await _tipoEventosRepository.PostTipoEvento(tipoEvento);
        }

        public async Task PutTipoEvento(TipoEvento tipoEvento)
        {
           await  _tipoEventosRepository.PutTipoEvento(tipoEvento);
        }
    }
}

