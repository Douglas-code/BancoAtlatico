using BancoAtlantico.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace BancoAtlantico.Domain.Entities
{
    public class CaixaEletronico : Entity
    {
        private readonly IList<Cedula> _cedulas;

        public CaixaEletronico()
        {
            this._cedulas = new List<Cedula>();
            this.Status = ECaixaStatus.Ativo;
        }

        public IReadOnlyCollection<Cedula> Cedulas => this._cedulas.ToArray(); 

        public ECaixaStatus Status { get; private set; }

        public void AdicionarNovaCedula(Cedula cedula)
        {
            this._cedulas.Add(cedula);
        }

        public void DepositarCedulas(int valor, int quantidade)
        {
            foreach(Cedula cedula in this._cedulas)
            {
                if(cedula.Valor == valor)
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

            foreach(Cedula cedula in Cedulas)
            {
                CedulasSaque.Add(cedula.Valor, cedula.DistribuirQantidadeNotasPorValor(ref valor));
            }

            return CedulasSaque;
        }
    }
}
