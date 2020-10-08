using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WAApuestas.DeportesSpace;
using WAApuestas.Models;
using WAApuestas.TiposApuestaSpace;
using WAApuestas.TiposEventoSpace;

namespace UTGestionApuestas
{
    [TestClass]
    public class UTTiposApuestasService
    {
        private ITiposApuestaService cut;
        private Mock<ITiposApuestaRepository> mockTiposApuestasRepository;
        private Mock<ITiposEventoRepository> mockTiposEventosRepository;
        private Mock<IDeportesRepository> mockDeportesRepository;
        private Mock<ILogger<TiposApuestaService>> moqLogger;

        [TestInitialize]
        public void SetUp()
        {
            this.mockTiposApuestasRepository = new Mock<ITiposApuestaRepository>();
            this.mockDeportesRepository = new Mock<IDeportesRepository>();
            this.mockTiposEventosRepository = new Mock<ITiposEventoRepository>();
            this.moqLogger = new Mock<ILogger<TiposApuestaService>>();
            this.cut = new TiposApuestaService(mockTiposApuestasRepository.Object, moqLogger.Object, mockTiposEventosRepository.Object, mockDeportesRepository.Object);
        }
        [TestMethod]
        public async Task TestGetTiposApuestasAsync()
        {
            IEnumerable<TipoApuesta> listTiposApuestas = new List<TipoApuesta>();

            listTiposApuestas.Append(new TipoApuesta
            {
                Id = 1,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""

            });
            listTiposApuestas.Append(new TipoApuesta
            {
                Id = 2,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""
            });
            mockTiposApuestasRepository.Setup(ta => ta.GetTiposApuesta()).ReturnsAsync(listTiposApuestas);

            var resultadoLeido = await cut.GetTiposApuesta();

            Assert.IsNotNull(resultadoLeido);
            Assert.AreEqual(listTiposApuestas, resultadoLeido);

            mockTiposApuestasRepository.Verify(r => r.GetTiposApuesta(), Times.Once());
        }
        [TestMethod]
        public async Task TestGetTipoApuestaAsync()
        {
            int idALeer = 1;
            TipoApuesta tipoApuestaLeida = new TipoApuesta
            {
                Id = 1,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""
            };

            mockTiposApuestasRepository.Setup(ta => ta.GetTipoApuesta(idALeer)).ReturnsAsync(tipoApuestaLeida);

            mockTiposApuestasRepository.Setup(ta => ta.TipoApuestaExists(idALeer)).ReturnsAsync(true);

            var tipoApuestaDevuelta = await cut.GetTipoApuesta(idALeer);

            Assert.AreEqual(tipoApuestaDevuelta, tipoApuestaLeida);
            mockTiposApuestasRepository.Verify(r => r.GetTipoApuesta(idALeer), Times.Once);
        }
        [TestMethod]
        public async Task TestActualizarAccionAsync()
        {
            TipoApuesta tipoApuesta = new TipoApuesta
            {
                Id = 1,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""
            };
            mockTiposApuestasRepository.Setup(ta => ta.TipoApuestaExists(tipoApuesta.Id)).ReturnsAsync(true);
            await cut.PutTipoApuesta(tipoApuesta);

            mockTiposApuestasRepository.Verify(r => r.PutTipoApuesta(It.IsAny<TipoApuesta>()), Times.Once());
        }
        [TestMethod]
        public async Task TestCrearAccionAsync()
        {
            TipoApuesta tipoApuesta = new TipoApuesta
            {
                Id = 1,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""
            };
            await cut.PostTipoApuesta(tipoApuesta);
            mockTiposApuestasRepository.Verify(tp => tp.PostTipoApuesta(It.IsAny<TipoApuesta>()), Times.Once());
        }

        [TestMethod]
        public async Task TestEliminarAccionAsync()
        {
            TipoApuesta apuestaEliminada = new TipoApuesta
            {
                Id = 4,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""
            };
            mockTiposApuestasRepository.Setup(ta => ta.DeleteTipoApuesta(4)).ReturnsAsync(apuestaEliminada);
            mockTiposApuestasRepository.Setup(ta => ta.TipoApuestaExists(4)).ReturnsAsync(true);

            var tipoApuestaDevuelta = await cut.DeleteTipoApuesta(4);

            Assert.AreEqual(tipoApuestaDevuelta, apuestaEliminada);
            mockTiposApuestasRepository.Verify(p => p.DeleteTipoApuesta(4), Times.Once());
        }
    }
}
