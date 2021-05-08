
using BancoAtlantico.Domain.Entities;
using BancoAtlantico.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BancoAtlantico.Tests.EntitiesTests
{
    [TestClass]
    public class CaixaEletronicoTests
    {
        private readonly Cedula _cedula100;
        private readonly Cedula _cedula50;
        private readonly Cedula _cedula20;
        private readonly Cedula _cedula10;
        private readonly Cedula _cedula5;
        private readonly Cedula _cedula2;
        private CaixaEletronico _caixaEletronico;

        public CaixaEletronicoTests()
        {
            this._cedula100 = new Cedula(100, 10);
            this._cedula50 = new Cedula(50, 10);
            this._cedula20 = new Cedula(20, 10);
            this._cedula10 = new Cedula(10, 10);
            this._cedula5 = new Cedula(5, 10);
            this._cedula2 = new Cedula(2, 10);

            this._caixaEletronico = new CaixaEletronico();
            this._caixaEletronico.AdicionarNovaCedula(this._cedula100);
            this._caixaEletronico.AdicionarNovaCedula(this._cedula50);
            this._caixaEletronico.AdicionarNovaCedula(this._cedula20);
            this._caixaEletronico.AdicionarNovaCedula(this._cedula10);
            this._caixaEletronico.AdicionarNovaCedula(this._cedula5);
            this._caixaEletronico.AdicionarNovaCedula(this._cedula2);
        }

        [TestMethod]
        public void DeveRetornarApenasUmaNotaDe50AoSacar50()
        {
            Dictionary<int, int> dic = this._caixaEletronico.EfetuarSaque(50);
            Assert.AreEqual(1, dic[50]);
        }

        [TestMethod]
        public void DeveMudarStatusParaDesativadoAoDesativarCaixa()
        {
            this._caixaEletronico.DesativarCaixa();
            Assert.AreEqual(ECaixaStatus.Desativado, this._caixaEletronico.Status);
        }

        [TestMethod]
        public void DeveRetornarUmaCedulaDe50DuasDe20UmaDe2AoSacar92()
        {
            Dictionary<int, int> dic = this._caixaEletronico.EfetuarSaque(92);
            Assert.AreEqual(1, dic[50]);
            Assert.AreEqual(2, dic[20]);
            Assert.AreEqual(1, dic[2]);
        }

        [TestMethod]
        public void DeveRetornar20AoAdicionar10NotasDe100()
        {
            this._caixaEletronico.DepositarCedulas(100, 10);
            int qtd = this._caixaEletronico.Cedulas.Where(x => x.Valor == 100).Select(s => s.Quantidade).FirstOrDefault();
            Assert.AreEqual(20, qtd);
        }
    }
}
