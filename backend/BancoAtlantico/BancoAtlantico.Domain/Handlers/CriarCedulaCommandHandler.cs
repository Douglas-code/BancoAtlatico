using BancoAtlantico.Domain.Commands;
using BancoAtlantico.Domain.Commands.Contracts;
using BancoAtlantico.Domain.Entities;
using BancoAtlantico.Domain.Handlers.Contracts;
using BancoAtlantico.Domain.Repositories;
using System.Threading.Tasks;

namespace BancoAtlantico.Domain.Handlers
{
    public class CriarCedulaCommandHandler : IHandler<CriarCedulaCommand>
    {
        private readonly ICedulaRepository _cedulaRepository;

        public CriarCedulaCommandHandler(ICedulaRepository cedulaRepository)
        {
            this._cedulaRepository = cedulaRepository;
        }

        public ICommandResult Handle(CriarCedulaCommand command)
        {
            Cedula cedula = new Cedula(command.Valor);
            bool cedulaExiste = this._cedulaRepository.VerificarDuplicidade(cedula);

            if (cedulaExiste)
                return new GenericCommandResult(false, "Cedula já existe!", null);

            this._cedulaRepository.Save(cedula);

            return new GenericCommandResult(true, "Salvo com sucesso!", cedula);
        }
    }
}
