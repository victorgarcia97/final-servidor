using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WAApuestas.DeportesSpace;
using WAApuestas.TiposEventoSpace;
using WAApuestas.TiposApuestaSpace;

namespace WAApuestas
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").WithMethods("GET", "PUT", "DELETE", "POST", "OPTIONS").AllowAnyHeader();
                    });
            });

            services.AddControllers();

            services.AddDbContext<GestionApuestasDbContext>();

            services.AddScoped<IDeportesService, DeportesService>();
            services.AddScoped<IDeportesRepository, DeportesRepository>();

            services.AddScoped<ITipoEventosService, TipoEventosService>();
            services.AddScoped<ITipoEventosRepository, TipoEventosRepository>();

            services.AddScoped<ITiposApuestasService, TiposApuestasService>();
            services.AddScoped<ITiposApuestasRepository, TiposApuestasRepository>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");
            });

        }
    }
}
