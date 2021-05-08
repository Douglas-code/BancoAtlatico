using BancoAtlantico.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BancoAtlantico.Tests.EntitiesTests
{
    [TestClass]
    public class CedulaTests
    {
        private readonly Cedula _cedula100;
        private readonly Cedula _cedula50;

        public CedulaTests()
        {
            this._cedula100 = new Cedula(100, 10);
            this._cedula50 = new Cedula(50, 0);
        }

        [TestMethod]
        public void DeveRetornar10AoAdicionar10Notasde50()
        {
            this._cedula50.Adicionar(10);
            Assert.AreEqual(10, this._cedula50.Quantidade);
        }

        [TestMethod]
        public void DeveRetornarNenhumaNotaDe100AoSolicitar50()
        {
            int valor = 50;
            Assert.AreEqual(0, this._cedula100.DistribuirQantidadeNotasPorValor(ref valor));
        }

        [TestMethod]
        public void DeveRetornarDuasNotaDe100AoSolicitar200()
        {
            int valor = 200;
            Assert.AreEqual(2, this._cedula100.DistribuirQantidadeNotasPorValor(ref valor));
        }
    }
}
