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
        public DbSet<TipoApuestas> TiposApuestas { get; set; }
        public DbSet<TipoEvento> TiposEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"));

        }

    }
}
