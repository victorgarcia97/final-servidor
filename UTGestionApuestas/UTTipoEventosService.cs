using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WAApuestas.Models;
using WAApuestas.TiposEventoSpace;

namespace UTGestionApuestas
{
    [TestClass]
    public class UTTipoEventosService
    {
        private ITipoEventosService cut;
        private Mock<ITipoEventosRepository> mockTipoEventosRepository;
        private Mock<ILogger<TipoEventosService>> moqLogger;

        [TestInitialize]
        public void SetUp()
        {
            this.mockTipoEventosRepository = new Mock<ITipoEventosRepository>();
            this.moqLogger = new Mock<ILogger<TipoEventosService>>();
            this.cut = new TipoEventosService(mockTipoEventosRepository.Object, moqLogger.Object);
        }
        [TestMethod]
        public async Task TestGetTipoEventosAsync()
        {
            IEnumerable<TipoEvento> listTipoEventos = new List<TipoEvento>();

            listTipoEventos.Append(new TipoEvento { 
                Id = 1,
                DeporteId = 1,
                Deporte = new Deporte{ Id = 1, Nombre = "Baloncesto" }, 
                Competicion = "Nba",
                FechaInicio = System.DateTime.Now , 
                FechaFin = System.DateTime.Now,
                Descripcion = "hola"
            });
            listTipoEventos.Append(new TipoEvento
            {
                Id = 2,
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                Competicion = "Nba" ,
                FechaInicio = System.DateTime.Now,
                FechaFin = System.DateTime.Now,
                Descripcion = "hola"
            });
            mockTipoEventosRepository.Setup(tp => tp.GetTiposEventos()).ReturnsAsync(listTipoEventos);

            var resultadoLeido = await cut.GetTiposEventos();

            Assert.IsNotNull(resultadoLeido);
            Assert.AreEqual(listTipoEventos, resultadoLeido);

            mockTipoEventosRepository.Verify(r => r.GetTiposEventos(), Times.Once());
        }
        [TestMethod]
        public async Task TestGetTipoEventoAsync()
        {
            int idALeer = 1;
            TipoEvento tipoEventoLeido = new TipoEvento
            {
                Id = 1,
                DeporteId = 1,
                Deporte = new Deporte{ Id = 1, Nombre = "Baloncesto" },
                Competicion = "Nba",
                FechaInicio = System.DateTime.Now,
                FechaFin = System.DateTime.Now,
                Descripcion = "hola"
            };

            mockTipoEventosRepository.Setup(tp => tp.GetTipoEvento(idALeer)).ReturnsAsync(tipoEventoLeido);

            mockTipoEventosRepository.Setup(tp => tp.TipoEventoExists(idALeer)).ReturnsAsync(true);

            var tipoEventoDevuelto = await cut.GetTipoEvento(idALeer);

            Assert.AreEqual(tipoEventoDevuelto, tipoEventoLeido);
            mockTipoEventosRepository.Verify(r => r.GetTipoEvento(idALeer), Times.Once);
        }
        [TestMethod]
        public async Task TestActualizarAccionAsync()
        {
            TipoEvento tipoEvento = new TipoEvento
            {
                Id = 1,
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                Competicion = "Nba",
                FechaInicio = System.DateTime.Now,
                FechaFin = System.DateTime.Now,
                Descripcion = "hola"
            };
            mockTipoEventosRepository.Setup(tp => tp.TipoEventoExists(tipoEvento.Id)).ReturnsAsync(true);
            await cut.PutTipoEvento(tipoEvento);

            mockTipoEventosRepository.Verify(r => r.PutTipoEvento(It.IsAny<TipoEvento>()), Times.Once());
        }
        [TestMethod]
        public async Task TestCrearAccionAsync()
        {
            TipoEvento tipoEvento = new TipoEvento
            {
                Id = 1,
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                Competicion = "Nba",
                FechaInicio = System.DateTime.Now,
                FechaFin = System.DateTime.Now,
                Descripcion = "hola"
            };
            await cut.PostTipoEvento(tipoEvento);
            mockTipoEventosRepository.Verify(tp => tp.PostTipoEvento(It.IsAny<TipoEvento>()), Times.Once());
        }

        [TestMethod]
        public async Task TestEliminarAccionAsync()
        {
            TipoEvento tipoEventoAEliminar = new TipoEvento
            {
                Id = 4,
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                Competicion = "Nba",
                FechaInicio = System.DateTime.Now,
                FechaFin = System.DateTime.Now,
                Descripcion = "hola"
            };
            mockTipoEventosRepository.Setup(tp => tp.DeleteTipoEvento(4)).ReturnsAsync(tipoEventoAEliminar);
            mockTipoEventosRepository.Setup(tp => tp.TipoEventoExists(4)).ReturnsAsync(true);

            var tipoEventoDevuelto = await cut.DeleteTipoEvento(4);

            Assert.AreEqual(tipoEventoDevuelto, tipoEventoAEliminar);
            mockTipoEventosRepository.Verify(p => p.DeleteTipoEvento(4), Times.Once());
        }

    }
}
