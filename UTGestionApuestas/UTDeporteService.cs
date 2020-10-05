using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WAApuestas.DeportesSpace;
using WAApuestas.Models;

namespace UTGestionApuestas
{
    [TestClass]
    public class UTDeporteService
    {
        private IDeportesService cut;
        private Mock<IDeportesRepository> mockDeporteRepository;
        private Mock<ILogger<DeportesService>> moqLogger;

        [TestInitialize]
        public void SetUp()
        {
            this.mockDeporteRepository = new Mock<IDeportesRepository>();
            this.moqLogger = new Mock<ILogger<DeportesService>>();
            this.cut = new DeportesService(mockDeporteRepository.Object, moqLogger.Object);
        }

        [TestMethod]
        public async Task TestGetDeportesAsync()
        {
            IEnumerable<Deporte> listTipoEventos = new List<Deporte>();

            listTipoEventos.Append(new Deporte
            {
                Id = 1,
                Nombre = "Baloncesto"
            });
            listTipoEventos.Append(new Deporte
            {
                Id = 2,
                Nombre = "Futbol"
            });
            mockDeporteRepository.Setup(d => d.GetDeportes()).ReturnsAsync(listTipoEventos);

            var resultadoLeido = await cut.GetDeportes();

            Assert.IsNotNull(resultadoLeido);
            Assert.AreEqual(listTipoEventos, resultadoLeido);

            mockDeporteRepository.Verify(r => r.GetDeportes(), Times.Once());
        }
        [TestMethod]
        public async Task TestGetDeporteAsync()
        {
            int idALeer = 1;
            Deporte deporteLeido = new Deporte
            {
                Id = 1,
                Nombre = "Baloncesto"
            };

            mockDeporteRepository.Setup(tp => tp.GetDeporte(idALeer)).ReturnsAsync(deporteLeido);

            var accionDevuelta = await cut.GetDeporte(idALeer);

            Assert.AreEqual(accionDevuelta, deporteLeido);
            mockDeporteRepository.Verify(r => r.GetDeporte(idALeer), Times.Once);
        }
    }
}
