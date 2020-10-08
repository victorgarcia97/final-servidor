
namespace WAApuestas.Models
{
    public class EventoTipoApuesta
    {
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public int TipoApuestaId { get; set; }
        public TipoApuesta TipoApuesta { get; set; }
    }
}
