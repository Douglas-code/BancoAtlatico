using BancoAtlantico.Domain.Commands.Contracts;
using System;

namespace BancoAtlantico.Domain.Commands
{
    public class DesativarCaixaEletronicoCommand : ICommand
    {
        public DesativarCaixaEletronicoCommand() { }

        public DesativarCaixaEletronicoCommand(Guid caixaEletronico)
        {
            CaixaEletronico = caixaEletronico;
        }

        public Guid CaixaEletronico { get; set; }
    }
}
