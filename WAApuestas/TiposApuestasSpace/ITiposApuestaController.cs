
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestaSpace
{
    public interface ITiposApuestaController
    {
        [HttpDelete("{id}")]
        Task<ActionResult<TipoApuesta>> DeleteTipoApuesta(int id);
        [HttpGet("{id}")]
        Task<ActionResult<TipoApuesta>> GetTipoApuesta(int id);
        [HttpGet]
        Task<IEnumerable<TipoApuesta>> GetTiposApuesta();
        [HttpPost]
        Task<ActionResult<TipoApuesta>> PostTipoApuesta(TipoApuesta tipoApuestas);
        [HttpPut("{id}")]
        Task<IActionResult> PutTipoApuesta(int id, TipoApuesta tipoApuestas);
    }
}
