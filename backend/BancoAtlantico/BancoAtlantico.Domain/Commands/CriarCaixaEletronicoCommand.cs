using BancoAtlantico.Domain.Commands.Contracts;
using BancoAtlantico.Domain.DataTransferObject.In;
using System.Collections.Generic;

namespace BancoAtlantico.Domain.Commands
{
    public class CriarCaixaEletronicoCommand : ICommand
    {
        public List<CedulaEstoqueDataTransferObjectIn> Cedulas { get; set; }
    }
}
