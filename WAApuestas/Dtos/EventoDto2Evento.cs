using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.Dtos
{
    public class EventoDto2Evento
    {

        public static Evento Dto2Model(EventoDto dto)
        {
            IList<EventoTipoApuesta> tiposApuestas = new List<EventoTipoApuesta>();

            for(int i = 0;  i < dto.TiposApuesta.Count; i++)
            {
                EventoTipoApuesta relacion = new EventoTipoApuesta()
                    { EventoId = dto.Id, TipoApuestaId = dto.TiposApuesta[i].Id };
                tiposApuestas.Add(relacion);
            }

            Evento modelo = new Evento() { Id = dto.Id, Nombre = dto.Nombre, Codigo = dto.Codigo, TipoEventoId = dto.TipoEventoId, TipoEvento = dto.TipoEvento, Activo = dto.Activo, EventosTiposApuesta = tiposApuestas };

            return modelo;
        }

        public static EventoDto Model2Dto(Evento modelo)
        {
            IList<TipoApuesta> tiposApuesta = new List<TipoApuesta>();

            for(int i = 0; i < modelo.EventosTiposApuesta.Count; i++)
            {
                TipoApuesta t = modelo.EventosTiposApuesta[i].TipoApuesta;
                tiposApuesta.Add(t);
            }

            EventoDto dto = new EventoDto() { Id = modelo.Id, Activo = modelo.Activo, Codigo = modelo.Codigo, Nombre = modelo.Nombre, TipoEvento = modelo.TipoEvento, TipoEventoId = modelo.TipoEventoId, TiposApuesta = tiposApuesta };

            return dto;
        }





    }
}
