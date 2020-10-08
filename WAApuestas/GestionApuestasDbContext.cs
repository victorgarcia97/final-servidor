using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WAApuestas.Models;

namespace WAApuestas
{
    public class GestionApuestasDbContext: DbContext
    {
        private readonly IConfiguration _Configuration;

        public GestionApuestasDbContext(IConfiguration configuracion) : base()
        {
            this._Configuration = configuracion;
        }

        public DbSet<Deporte> Deportes { get; set; }
        public DbSet<TipoApuesta> TiposApuesta { get; set; }
        public DbSet<TipoEvento> TiposEvento { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoTipoApuesta> EventosTiposApuesta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventoTipoApuesta>()
                .HasKey(k => new { k.EventoId, k.TipoApuestaId });

            modelBuilder.Entity<EventoTipoApuesta>()
                .HasOne(e => e.Evento)
                .WithMany(tr => tr.EventosTiposApuesta)
                .HasForeignKey(e => e.EventoId);

            modelBuilder.Entity<EventoTipoApuesta>()
                .HasOne(ta => ta.TipoApuesta)
                .WithMany(et => et.EventosTiposApuesta)
                .HasForeignKey(ta => ta.TipoApuestaId);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"));

        }

    }
}
