using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WAApuestas.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }


        public int TipoEventoId { get; set; }
        public TipoEvento TipoEvento { get; set; }

        public Boolean Activo { get; set; }

        [JsonIgnore]
        public IList<EventoTipoApuesta> EventosTiposApuesta { get; set; }
        
    }
}
