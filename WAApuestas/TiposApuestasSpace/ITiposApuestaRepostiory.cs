using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestaSpace
{
    public interface ITiposApuestaRepository
    {
        Task<TipoApuesta> DeleteTipoApuesta(int id);
        Task<TipoApuesta> GetTipoApuesta(int id);
        Task<IEnumerable<TipoApuesta>> GetTiposApuesta();
        Task<TipoApuesta> PostTipoApuesta(TipoApuesta tipoApuestas);
        Task<TipoApuesta> PutTipoApuesta(TipoApuesta tipoApuestas);
        Task<bool> TipoApuestaExists(int id);
    }
}
