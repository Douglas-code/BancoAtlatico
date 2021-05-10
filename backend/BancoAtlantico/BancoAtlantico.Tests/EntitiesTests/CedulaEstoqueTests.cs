using BancoAtlantico.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BancoAtlantico.Tests.EntitiesTests
{
    [TestClass]
    public class CedulaEstoqueTests
    {
        private readonly Cedula _cedula100;
        private readonly CedulaEstoque _cedulaEstoque100;
        private readonly Cedula _cedula50;
        private readonly CedulaEstoque _cedulaEstoque50;
        private readonly CaixaEletronico _caixaEletronico;

        public CedulaEstoqueTests()
        {
            this._caixaEletronico = new CaixaEletronico();
            this._cedula100 = new Cedula(100);
            this._cedulaEstoque100 = new CedulaEstoque(this._cedula100, 10, this._caixaEletronico);
            this._cedula50 = new Cedula(50);
            this._cedulaEstoque50 = new CedulaEstoque(this._cedula50, 0, this._caixaEletronico);
        }

        [TestMethod]
        public void DeveRetornar10AoAdicionar10Notasde50()
        {
            this._cedulaEstoque50.Adicionar(10);
            Assert.AreEqual(10, this._cedulaEstoque50.Quantidade);
        }

        [TestMethod]
        public void DeveRetornarNenhumaNotaDe100AoSolicitar50()
        {
            int valor = 50;
            Assert.AreEqual(0, this._cedulaEstoque100.DistribuirQantidadeNotasPorValor(ref valor));
        }

        [TestMethod]
        public void DeveRetornarDuasNotaDe100AoSolicitar200()
        {
            int valor = 200;
            Assert.AreEqual(2, this._cedulaEstoque100.DistribuirQantidadeNotasPorValor(ref valor));
        }
    }
}
