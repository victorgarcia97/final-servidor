using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAApuestas.Models;

namespace WAApuestas.DeportesSpace
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeportesController : ControllerBase, IDeportesController
    {
        private readonly IDeportesService _deportesService;

        public DeportesController(IDeportesService deportesService)
        {
            _deportesService = deportesService;
        }

        // GET: api/Deportes
        [HttpGet]
        public async Task<IEnumerable<Deporte>> GetDeportes()
        {
            return await _deportesService.GetDeportes();
        }

        // GET: api/Deportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deporte>> GetDeporte(int id)
        {
            Deporte deporte;

            try
            {
                deporte = await _deportesService.GetDeporte(id);
            }
            catch(GestionApuestasException e)
            {
                return NotFound(e.Message);
            }

            return deporte;
        }
    }
}
