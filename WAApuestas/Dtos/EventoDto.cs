using System;
using System.Collections.Generic;
using WAApuestas.Models;

namespace WAApuestas.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }


        public int TipoEventoId { get; set; }
        public TipoEvento TipoEvento { get; set; }

        public Boolean Activo { get; set; }

        public IList<TipoApuesta> TiposApuesta { get; set; }
    }
}
