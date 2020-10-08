using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WAApuestas.Models
{
    public class TipoApuesta
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Multiplicador { get; set; }
        public string Riesgo { get; set; }

        public int DeporteId { get; set; }
        public Deporte Deporte { get; set; }

        public string NotasExtra { get; set; }

        [JsonIgnore]
        public List<EventoTipoApuesta> EventosTiposApuesta { get; set; }
    }
}
