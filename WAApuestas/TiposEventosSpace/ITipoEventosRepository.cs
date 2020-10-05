using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.TiposEventosSpace
{
    public interface ITipoEventosRepository
    {
        Task<TipoEvento> DeleteTipoEvento(int id);
        Task<TipoEvento> GetTipoEvento(int id);
        Task<IEnumerable<TipoEvento>> GetTiposEventos();
        Task<TipoEvento> PostTipoEvento(TipoEvento tipoEvento);
        Task PutTipoEvento(TipoEvento tipoEvento);
        Task<bool> TipoEventoExists(int id);
    }
}
