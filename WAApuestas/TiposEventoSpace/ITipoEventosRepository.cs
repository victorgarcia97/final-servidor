using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.TiposEventoSpace
{
    public interface ITiposEventoRepository
    {
        Task<TipoEvento> DeleteTipoEvento(int id);
        Task<TipoEvento> GetTipoEvento(int id);
        Task<IEnumerable<TipoEvento>> GetTiposEvento();
        Task<TipoEvento> PostTipoEvento(TipoEvento tipoEvento);
        Task<TipoEvento>  PutTipoEvento(TipoEvento tipoEvento);
        Task<bool> TipoEventoExists(int id);
    }
}
