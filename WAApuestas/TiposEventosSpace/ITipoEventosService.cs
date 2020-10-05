using System.Collections.Generic;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.TiposEventosSpace
{
    public interface ITipoEventosService
    {
        Task<TipoEvento> DeleteTipoEvento(int id);
        Task<TipoEvento> GetTipoEvento(int id);
        Task<IEnumerable<TipoEvento>> GetTiposEventos();
        Task<TipoEvento> PostTipoEvento(TipoEvento tipoEvento);
        Task PutTipoEvento(TipoEvento tipoEvento);
    }
}
