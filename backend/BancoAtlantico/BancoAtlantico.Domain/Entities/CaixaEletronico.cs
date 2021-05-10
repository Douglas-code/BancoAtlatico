using BancoAtlantico.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoAtlantico.Domain.Entities
{
    public class CaixaEletronico : Entity
    {
        private readonly IList<CedulaEstoque> _cedulas;

        public CaixaEletronico()
        {
            this._cedulas = new List<CedulaEstoque>();
            this.Status = ECaixaStatus.Ativo;
            this.Id = new Guid();
        }

        public IReadOnlyCollection<CedulaEstoque> Cedulas => this._cedulas.ToArray(); 

        public ECaixaStatus Status { get; private set; }

        public void AdicionarNovaCedula(CedulaEstoque cedula)
        {
            this._cedulas.Add(cedula);
        }

        public void DepositarCedulas(int valor, int quantidade)
        {
            foreach(CedulaEstoque cedula in this._cedulas)
            {
                if (cedula.Cedula.Valor == valor)
                {
                    cedula.Adicionar(quantidade);
                }
            }
        }

        public void DesativarCaixa()
        {
            this.Status = ECaixaStatus.Desativado;
        }

        public Dictionary<int, int> EfetuarSaque(int valor)
        {
            Dictionary<int, int> CedulasSaque = new Dictionary<int, int>();

            foreach(CedulaEstoque cedulaEstoque in this.Cedulas)
            {
                CedulasSaque.Add(cedulaEstoque.Cedula.Valor, cedulaEstoque.DistribuirQantidadeNotasPorValor(ref valor));
            }

            return CedulasSaque;
        }

        public int TotalEmCaixa()
        {
            int total = 0;

            foreach(var cedula in this.Cedulas)
            {
                total += (cedula.Cedula.Valor * cedula.Quantidade);
            }

            return total;
        }
    }
}
