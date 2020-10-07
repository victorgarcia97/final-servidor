using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAApuestas.Models
{
    public class TipoApuestas
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Multiplicador { get; set; }
        public string Riesgo { get; set; }

        public int DeporteId { get; set; }
        public Deporte Deporte { get; set; }

        public string NotasExtra { get; set; }
    }
}
