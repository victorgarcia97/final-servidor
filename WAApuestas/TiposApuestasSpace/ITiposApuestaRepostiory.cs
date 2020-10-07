using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestaSpace
{
    public interface ITiposApuestaRepository
    {
        Task<TipoApuestas> DeleteTipoApuesta(int id);
        Task<TipoApuestas> GetTipoApuesta(int id);
        Task<IEnumerable<TipoApuestas>> GetTiposApuesta();
        Task<TipoApuestas> PostTipoApuesta(TipoApuestas tipoApuestas);
        Task PutTipoApuesta(TipoApuestas tipoApuestas);
        Task<bool> TipoApuestaExists(int id);
    }
}
