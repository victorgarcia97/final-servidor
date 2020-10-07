using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAApuestas.Models;

namespace WAApuestas.DeportesSpace
{
    public interface IDeportesController
    {
        [HttpGet("{id}")]
        Task<ActionResult<Deporte>> GetDeporte(int id);
        [HttpGet]
        Task<IEnumerable<Deporte>> GetDeportes();
    }
}
