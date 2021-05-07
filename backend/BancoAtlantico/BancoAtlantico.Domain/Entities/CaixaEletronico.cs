using BancoAtlantico.Domain.Enums;
using System.Collections.Generic;

namespace BancoAtlantico.Domain.Entities
{
    public class CaixaEletronico : Entity
    {
        public CaixaEletronico()
        {
            this.Cedulas = new List<Cedula>();
            this.Status = ECaixaStatus.Ativo;
        }

        public List<Cedula> Cedulas { get; set; }

        public ECaixaStatus Status { get; set; }

        public void AdicionarNovaCedula(Cedula cedula)
        {
            this.Cedulas.Add(cedula);
        }

        public void DepositarCedulas(int valor, int quantidade)
        {
            foreach(Cedula cedula in Cedulas)
            {
                if(cedula.Valor == valor)
                {
                    cedula.Adicionar(valor);
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
                CedulasSaque.Add(cedula.Valor, cedula.DistribuirQantidadeNotasPorValor(&valor));
            }

            return CedulasSaque;
        }
    }
}
