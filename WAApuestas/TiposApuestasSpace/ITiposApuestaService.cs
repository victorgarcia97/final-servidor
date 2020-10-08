using System.Collections.Generic;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestaSpace
{
    public interface ITiposApuestaService
    {
        Task<TipoApuesta> DeleteTipoApuesta(int id);
        Task<TipoApuesta> GetTipoApuesta(int id);
        Task<IEnumerable<TipoApuesta>> GetTiposApuesta();
        Task<IEnumerable<TipoApuesta>> GetTiposApuestasPorDeporte(int tipoEventoId);
        Task<TipoApuesta> PostTipoApuesta(TipoApuesta tipoApuestas);
        Task PutTipoApuesta(TipoApuesta tipoApuestas);
    }
}
