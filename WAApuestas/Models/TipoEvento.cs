using System;

namespace WAApuestas.Models
{
    public class TipoEvento
    {
        public int Id { get; set; }

        public int DeporteId { get; set; }
        public Deporte Deporte { get; set; }
        
        public string Competicion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }
    }
}
