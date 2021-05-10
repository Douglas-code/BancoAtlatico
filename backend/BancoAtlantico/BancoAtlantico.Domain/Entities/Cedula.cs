using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BancoAtlantico.Domain.Entities
{
    public class Cedula : Entity
    {
        public Cedula()
        {
            this.Id = new Guid();
        }

        public Cedula(int valor)
        {
            this.Valor = valor;
            this.CedulasEstoque = new List<CedulaEstoque>();
            this.Id = new Guid();
        }

        public int Valor { get; private set; }

        [JsonIgnore]
        public List<CedulaEstoque> CedulasEstoque { get; set; }
    }
}
