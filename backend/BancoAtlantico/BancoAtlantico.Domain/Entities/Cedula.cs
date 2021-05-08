namespace BancoAtlantico.Domain.Entities
{
    public class Cedula : Entity
    {
        public Cedula(int valor, int quantidade)
        {
            this.Valor = valor;
            this.Quantidade = quantidade;
        }

        public int Valor { get; private set; }

        public int Quantidade { get; private set; }

        public int DistribuirQantidadeNotasPorValor(ref int montante)
        {
            int cedulasDistribuidas = 0;

            while(montante >= this.Valor && montante > 0 && this.Quantidade > 0)
            {
                montante -= this.Valor;
                this.Quantidade--;
                cedulasDistribuidas++;
            }

            return cedulasDistribuidas;
        }

        public void Adicionar(int quantidade)
        {
            this.Quantidade += quantidade;
        }
    }
}
