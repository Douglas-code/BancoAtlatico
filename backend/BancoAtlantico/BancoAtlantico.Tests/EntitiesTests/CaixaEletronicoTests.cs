
using BancoAtlantico.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            Assert.Equals(1, dic[50]);
        }
    }
}
