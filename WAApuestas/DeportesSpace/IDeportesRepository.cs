using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAApuestas.Models;

namespace WAApuestas.DeportesSpace
{
    public interface IDeportesRepository
    {
        Task<Deporte> GetDeporte(int id);
        Task<IEnumerable<Deporte>> GetDeportes();
    }
}
