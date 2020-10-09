using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAApuestas.Models;

namespace WAApuestas.TiposEventoSpace
{
    public interface ITiposEventoController
    {
        [HttpDelete("{id}")]
        Task<ActionResult<TipoEvento>> DeleteTipoEvento(int id);
        [HttpGet("{id}")]
        Task<ActionResult<TipoEvento>> GetTipoEvento(int id);
        [HttpGet]
        Task<IEnumerable<TipoEvento>> GetTiposEventos();
        [HttpPost]
        Task<ActionResult<TipoEvento>> PostTipoEvento(TipoEvento tipoEvento);
        [HttpPut("{id}")]
        Task<ActionResult<TipoEvento>> PutTipoEvento(int id, TipoEvento tipoEvento);
    }
}
