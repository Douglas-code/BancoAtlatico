using BancoAtlantico.Domain.Commands.Contracts;

namespace BancoAtlantico.Domain.Commands
{
    public class CriarCedulaCommand : ICommand
    {
        public int Valor { get; set; }
    }
}
