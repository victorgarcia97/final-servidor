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
        private readonly ILogger<ITiposEventoService> _loggerService;

        public TiposEventoService(ITiposEventoRepository tipoEventosRepository, ILogger<TiposEventoService> loggerService)
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

        public async Task<IEnumerable<TipoEvento>> GetTiposEvento()
        {
            return await _tipoEventosRepository.GetTiposEvento();
        }

        public async Task<TipoEvento> PostTipoEvento(TipoEvento tipoEvento)
        {
            return await _tipoEventosRepository.PostTipoEvento(tipoEvento);
        }

        public async Task<TipoEvento>  PutTipoEvento(TipoEvento tipoEvento)
        {
           return await  _tipoEventosRepository.PutTipoEvento(tipoEvento);
        }
    }
}

