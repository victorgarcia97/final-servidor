using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.EventosSpace
{
    public interface IEventosRepository
    {
        Task<Evento> DeleteEvento(int id);
        Task<Evento> GetEvento(int id);
        Task<IEnumerable<Evento>> GetEventos();
        Task<Evento> PostEvento(Evento evento);
        Task<Evento> PutEvento(Evento evento);
    }
}
