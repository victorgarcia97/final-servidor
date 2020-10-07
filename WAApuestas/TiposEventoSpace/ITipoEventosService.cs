using System.Collections.Generic;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.TiposEventoSpace
{
    public interface ITiposEventoService
    {
        Task<TipoEvento> DeleteTipoEvento(int id);
        Task<TipoEvento> GetTipoEvento(int id);
        Task<IEnumerable<TipoEvento>> GetTiposEvento();
        Task<TipoEvento> PostTipoEvento(TipoEvento tipoEvento);
        Task PutTipoEvento(TipoEvento tipoEvento);
    }
}
