using System.Collections.Generic;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestaSpace
{
    public interface ITiposApuestaService
    {
        Task<TipoApuestas> DeleteTipoApuesta(int id);
        Task<TipoApuestas> GetTipoApuesta(int id);
        Task<IEnumerable<TipoApuestas>> GetTiposApuesta();
        Task<TipoApuestas> PostTipoApuesta(TipoApuestas tipoApuestas);
        Task PutTipoApuesta(TipoApuestas tipoApuestas);
    }
}
