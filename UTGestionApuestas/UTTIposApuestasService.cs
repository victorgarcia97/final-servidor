using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WAApuestas.Models;
using WAApuestas.TiposApuestaSpace;

namespace UTGestionApuestas
{
    [TestClass]
    public class UTTiposApuestasService
    {
        private ITiposApuestasService cut;
        private Mock<ITiposApuestasRepository> mockTiposApuestasRepository;
        private Mock<ILogger<TiposApuestasService>> moqLogger;

        [TestInitialize]
        public void SetUp()
        {
            this.mockTiposApuestasRepository = new Mock<ITiposApuestasRepository>();
            this.moqLogger = new Mock<ILogger<TiposApuestasService>>();
            this.cut = new TiposApuestasService(mockTiposApuestasRepository.Object, moqLogger.Object);
        }
        [TestMethod]
        public async Task TestGetTiposApuestasAsync()
        {
            IEnumerable<TipoApuestas> listTiposApuestas = new List<TipoApuestas>();

            listTiposApuestas.Append(new TipoApuestas
            {
                Id = 1,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""

            });
            listTiposApuestas.Append(new TipoApuestas
            {
                Id = 2,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""
            });
            mockTiposApuestasRepository.Setup(ta => ta.GetTiposApuestas()).ReturnsAsync(listTiposApuestas);

            var resultadoLeido = await cut.GetTiposApuestas();

            Assert.IsNotNull(resultadoLeido);
            Assert.AreEqual(listTiposApuestas, resultadoLeido);

            mockTiposApuestasRepository.Verify(r => r.GetTiposApuestas(), Times.Once());
        }
        [TestMethod]
        public async Task TestGetTipoApuestaAsync()
        {
            int idALeer = 1;
            TipoApuestas tipoApuestaLeida = new TipoApuestas
            {
                Id = 1,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""
            };

            mockTiposApuestasRepository.Setup(ta => ta.GetTipoApuestas(idALeer)).ReturnsAsync(tipoApuestaLeida);

            mockTiposApuestasRepository.Setup(ta => ta.TipoApuestasExists(idALeer)).ReturnsAsync(true);

            var tipoApuestaDevuelta = await cut.GetTipoApuestas(idALeer);

            Assert.AreEqual(tipoApuestaDevuelta, tipoApuestaLeida);
            mockTiposApuestasRepository.Verify(r => r.GetTipoApuestas(idALeer), Times.Once);
        }
        [TestMethod]
        public async Task TestActualizarAccionAsync()
        {
            TipoApuestas tipoApuesta = new TipoApuestas
            {
                Id = 1,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""
            };
            mockTiposApuestasRepository.Setup(ta => ta.TipoApuestasExists(tipoApuesta.Id)).ReturnsAsync(true);
            await cut.PutTipoApuestas(tipoApuesta);

            mockTiposApuestasRepository.Verify(r => r.PutTipoApuestas(It.IsAny<TipoApuestas>()), Times.Once());
        }
        [TestMethod]
        public async Task TestCrearAccionAsync()
        {
            TipoApuestas tipoApuesta = new TipoApuestas
            {
                Id = 1,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""
            };
            await cut.PostTipoApuestas(tipoApuesta);
            mockTiposApuestasRepository.Verify(tp => tp.PostTipoApuestas(It.IsAny<TipoApuestas>()), Times.Once());
        }

        [TestMethod]
        public async Task TestEliminarAccionAsync()
        {
            TipoApuestas apuestaEliminada = new TipoApuestas
            {
                Id = 4,
                Descripcion = "Al ganador",
                Multiplicador = 1,
                Riesgo = "Medio",
                DeporteId = 1,
                Deporte = new Deporte { Id = 1, Nombre = "Baloncesto" },
                NotasExtra = ""
            };
            mockTiposApuestasRepository.Setup(ta => ta.DeleteTipoApuestas(4)).ReturnsAsync(apuestaEliminada);
            mockTiposApuestasRepository.Setup(ta => ta.TipoApuestasExists(4)).ReturnsAsync(true);

            var tipoApuestaDevuelta = await cut.DeleteTipoApuestas(4);

            Assert.AreEqual(tipoApuestaDevuelta, apuestaEliminada);
            mockTiposApuestasRepository.Verify(p => p.DeleteTipoApuestas(4), Times.Once());
        }
    }
}
