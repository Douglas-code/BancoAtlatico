using BancoAtlantico.Domain.Commands;
using BancoAtlantico.Domain.Commands.Contracts;
using BancoAtlantico.Domain.Handlers.Contracts;
using BancoAtlantico.Domain.Repositories;
using System.Threading.Tasks;

namespace BancoAtlantico.Domain.Handlers
{
    public class SaqueCommandHandler : IHandler<SaqueCommand>
    {
        private readonly ICaixaEletronicoRepository _caixaEletronicoRepository;
        private readonly ICedulaRepository _cedulaRepository;

        public SaqueCommandHandler(ICaixaEletronicoRepository caixaEletronicoRepository, ICedulaRepository cedulaRepository)
        {
            this._caixaEletronicoRepository = caixaEletronicoRepository;
            this._cedulaRepository = cedulaRepository;
        }

        public async Task<ICommandResult> Handle(SaqueCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "falha ao efetuar saque", command.Notifications);

            var caixaEletronico = await this._caixaEletronicoRepository.ObterCaixaEletronicoPorId(command.CaixaEletronico);
            var notas = caixaEletronico.EfetuarSaque(command.Valor);

            foreach(var cedula in caixaEletronico.Cedulas)
            {
                if (notas[cedula.Valor] > 0)
                    this._cedulaRepository.Update(cedula);
            }

            return new GenericCommandResult(true, "Saque Efetuado com sucesso!", notas);
        }
    }
}
