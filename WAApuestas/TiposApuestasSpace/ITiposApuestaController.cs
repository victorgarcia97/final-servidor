
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestaSpace
{
    public interface ITiposApuestaController
    {
        [HttpDelete("{id}")]
        Task<ActionResult<TipoApuestas>> DeleteTipoApuesta(int id);
        [HttpGet("{id}")]
        Task<ActionResult<TipoApuestas>> GetTipoApuesta(int id);
        [HttpGet]
        Task<IEnumerable<TipoApuestas>> GetTiposApuesta();
        [HttpPost]
        Task<ActionResult<TipoApuestas>> PostTipoApuesta(TipoApuestas tipoApuestas);
        [HttpPut("{id}")]
        Task<IActionResult> PutTipoApuesta(int id, TipoApuestas tipoApuestas);
    }
}
