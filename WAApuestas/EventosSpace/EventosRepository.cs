using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WAApuestas.Models;

namespace WAApuestas.EventosSpace
{
    public class EventosRepository: IEventosRepository
    {
        private readonly GestionApuestasDbContext _context;

        public EventosRepository(GestionApuestasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetEventos()
        {
            return await _context.Eventos
                                    .Include(t => t.TipoEvento)
                                    .Include(ta => ta.EventosTiposApuesta)
                                    .ThenInclude(tr => tr.TipoApuesta)
                                    .ThenInclude(d => d.Deporte)
                                    .ToListAsync();
        }

        public async Task<Evento> GetEvento(int id)
        {
            var evento = await _context.Eventos
                                           .Where(e => e.Id == id)
                                           .Include(t => t.TipoEvento)
                                           .Include(ta => ta.EventosTiposApuesta)
                                           .ThenInclude(tr => tr.TipoApuesta)
                                           .ThenInclude(d => d.Deporte)
                                           .FirstOrDefaultAsync();

            if (evento == null)
            {
                return null;
            }

            return evento;
        }

        public async Task<Evento> PutEvento(Evento evento)
        {

            List<EventoTipoApuesta> eventosTiposApuestas = await _context.EventosTiposApuesta.Where(et => et.EventoId == evento.Id).ToListAsync();
            
            _context.EventosTiposApuesta.RemoveRange(eventosTiposApuestas);
            

           _context.EventosTiposApuesta.AddRange(evento.EventosTiposApuesta);
            

            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await this.GetEvento(evento.Id);
        }

        public async Task<Evento> PostEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return await this.GetEvento(evento.Id);
        }

        public async Task<Evento> DeleteEvento(int id)
        {
            var evento = await _context.Eventos
                                           .Where(e => e.Id == id)
                                           .Include(t => t.TipoEvento)
                                           .Include(ta => ta.EventosTiposApuesta)
                                           .ThenInclude(tr => tr.TipoApuesta)
                                           .ThenInclude(d => d.Deporte)
                                           .FirstOrDefaultAsync();

            if (evento == null)
            {
                return null;
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return evento;
        }
    }
}
