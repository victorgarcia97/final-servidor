using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAApuestas.DeportesSpace;
using WAApuestas.Models;
using WAApuestas.TiposApuestaSpace;
using WAApuestas.TiposEventoSpace;

namespace WAApuestas.EventosSpace
{
    public class EventosService : IEventosService
    {
        private readonly IEventosRepository _eventosRepository;

        public EventosService(IEventosRepository eventosRepository)
        {
            _eventosRepository = eventosRepository;
        }



        public async Task<Evento> DeleteEvento(int id)
        {
            var evento = await _eventosRepository.DeleteEvento(id);

            if(evento == null)
            {
                throw new GestionApuestasException("No se encuentra el evento que se quiere borrar");
            }

            return evento;
        }

        public async Task<Evento> GetEvento(int id)
        {
            var evento = await _eventosRepository.GetEvento(id);

            if (evento == null)
            {
                throw new GestionApuestasException("No se encuentra el evento buscado");
            }

            return evento;
        }

        public async Task<IEnumerable<Evento>> GetEventos()
        {
            return await _eventosRepository.GetEventos();
        }

        public async Task<Evento> PostEvento(Evento evento)
        {
            return await _eventosRepository.PostEvento(evento);
        }

        public async Task<Evento> PutEvento(Evento evento)
        {
            return await _eventosRepository.PutEvento(evento);
        }
    }
}
