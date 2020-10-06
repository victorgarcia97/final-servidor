using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WAApuestas.Models;

namespace WAApuestas.TiposApuestasSpace
{
    public class TiposApuestasService : ITiposApuestasService
    {
        private readonly ITiposApuestasRepository _tiposApuestasRepository;
        private readonly ILogger<ITiposApuestasService> _logger;

        public TiposApuestasService(ITiposApuestasRepository tiposApuestasRepository, ILogger<TiposApuestasService> logger)
        {
            _tiposApuestasRepository = tiposApuestasRepository;
            _logger = logger;
        }

        public async Task<TipoApuestas> DeleteTipoApuestas(int id)
        {
            var tipoApuesta = await _tiposApuestasRepository.DeleteTipoApuestas(id);

            if(tipoApuesta == null)
            {
                throw new GestionApuestasException("No se encuentra el tipo de apuesta para borrar");
            }

            return tipoApuesta;
        }

        public async Task<TipoApuestas> GetTipoApuestas(int id)
        {
            var tipoApuesta = await _tiposApuestasRepository.GetTipoApuestas(id);

            if(tipoApuesta == null)
            {
                throw new GestionApuestasException("No se encuentra el tipo de apuesta");
            }
            return tipoApuesta;

        }

        public async Task<IEnumerable<TipoApuestas>> GetTiposApuestas()
        {
            return await _tiposApuestasRepository.GetTiposApuestas();
        }

        public async Task<TipoApuestas> PostTipoApuestas(TipoApuestas tipoApuestas)
        {
            return await _tiposApuestasRepository.PostTipoApuestas(tipoApuestas);
        }

        public async Task PutTipoApuestas(TipoApuestas tipoApuestas)
        {
            await _tiposApuestasRepository.PutTipoApuestas(tipoApuestas);
        }
    }
}
