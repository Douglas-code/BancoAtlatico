using System;
using System.Text.Json.Serialization;

namespace BancoAtlantico.Domain.Entities
{
    public class CedulaEstoque : Entity
    {
        public CedulaEstoque()
        {
            this.Id = new Guid();
        }

        public CedulaEstoque(Cedula cedula, int quantidade, CaixaEletronico caixaEletronico)
        {
            this.Cedula = cedula;
            this.Quantidade = quantidade;
            this.CaixaEletronico = caixaEletronico;
            this.Id = new Guid();
        }
        
        public Cedula Cedula { get; private set; }

        public int Quantidade { get; private set; }

        [JsonIgnore]
        public CaixaEletronico CaixaEletronico { get; private set; }

        public int DistribuirQantidadeNotasPorValor(ref int montante)
        {
            int cedulasDistribuidas = 0;

            while (montante >= this.Cedula.Valor && montante > 0 && this.Quantidade > 0)
            {
                montante -= this.Cedula.Valor;
                this.Quantidade--;
                cedulasDistribuidas++;
            }

            return cedulasDistribuidas;
        }

        public void Adicionar(int quantidade)
        {
            this.Quantidade += quantidade;
        }

        public void GerarNovoGuid()
        {
            this.Id = new System.Guid();
        }
    }
}
