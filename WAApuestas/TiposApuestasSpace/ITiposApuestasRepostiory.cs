using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestaSpace
{
    public interface ITiposApuestasRepository
    {
        Task<TipoApuestas> DeleteTipoApuestas(int id);
        Task<TipoApuestas> GetTipoApuestas(int id);
        Task<IEnumerable<TipoApuestas>> GetTiposApuestas();
        Task<TipoApuestas> PostTipoApuestas(TipoApuestas tipoApuestas);
        Task PutTipoApuestas(TipoApuestas tipoApuestas);
        Task<bool> TipoApuestasExists(int id);
    }
}
