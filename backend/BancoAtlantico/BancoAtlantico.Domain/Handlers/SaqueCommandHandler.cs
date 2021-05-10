using BancoAtlantico.Domain.Commands;
using BancoAtlantico.Domain.Commands.Contracts;
using BancoAtlantico.Domain.Entities;
using BancoAtlantico.Domain.Handlers.Contracts;
using BancoAtlantico.Domain.Repositories;
using System.Threading.Tasks;

namespace BancoAtlantico.Domain.Handlers
{
    public class SaqueCommandHandler : IHandler<SaqueCommand>
    {
        private readonly ICaixaEletronicoRepository _caixaEletronicoRepository;
        private readonly ICedulaEstoqueRepository _cedulaEstoqueRepository;

        public SaqueCommandHandler(ICaixaEletronicoRepository caixaEletronicoRepository, ICedulaEstoqueRepository cedulaEstoqueRepository)
        {
            this._caixaEletronicoRepository = caixaEletronicoRepository;
            this._cedulaEstoqueRepository = cedulaEstoqueRepository;
        }

        public ICommandResult Handle(SaqueCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "falha ao efetuar saque", command.Notifications);

            CaixaEletronico caixaEletronico = this._caixaEletronicoRepository.ObterCaixaEletronicoPorId(command.CaixaEletronico);

            if (command.Valor > caixaEletronico.TotalEmCaixa())
                return new GenericCommandResult(false, "falha ao efetuar saque", command.Notifications);

            var notas = caixaEletronico.EfetuarSaque(command.Valor);

            foreach(var cedula in caixaEletronico.Cedulas)
            {
                if (notas[cedula.Cedula.Valor] > 0)
                    this._cedulaEstoqueRepository.Update(cedula);
            }

            return new GenericCommandResult(true, "Saque Efetuado com sucesso!", notas);
        }
    }
}
