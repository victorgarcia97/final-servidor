using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAApuestas.Dtos;

namespace WAApuestas.EventosSpace
{
    public interface IEventosController
    {
        [HttpDelete("{id}")]
        Task<ActionResult<EventoDto>> DeleteEvento(int id);
        [HttpGet("{id}")]
        Task<ActionResult<EventoDto>> GetEvento(int id);
        [HttpGet]
        Task<IEnumerable<EventoDto>> GetEventos();
        [HttpPost]
        Task<ActionResult<EventoDto>> PostEvento(EventoDto evento);
        [HttpPut("{id}")]
        Task<ActionResult<EventoDto>> PutEvento(int id, EventoDto evento);
    }
}
