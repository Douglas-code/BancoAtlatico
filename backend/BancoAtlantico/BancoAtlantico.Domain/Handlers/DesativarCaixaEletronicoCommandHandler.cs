using BancoAtlantico.Domain.Commands;
using BancoAtlantico.Domain.Commands.Contracts;
using BancoAtlantico.Domain.Entities;
using BancoAtlantico.Domain.Handlers.Contracts;
using BancoAtlantico.Domain.Repositories;
using System.Threading.Tasks;

namespace BancoAtlantico.Domain.Handlers
{
    public class DesativarCaixaEletronicoCommandHandler : IHandler<DesativarCaixaEletronicoCommand>
    {
        private readonly ICaixaEletronicoRepository _caixaEletronicoRepository;

        public DesativarCaixaEletronicoCommandHandler(ICaixaEletronicoRepository caixaEletronicoRepository)
        {
            _caixaEletronicoRepository = caixaEletronicoRepository;
        }

        public ICommandResult Handle(DesativarCaixaEletronicoCommand command)
        {
            CaixaEletronico caixaEletronico = this._caixaEletronicoRepository.ObterCaixaEletronicoPorId(command.CaixaEletronico);

            if (caixaEletronico == null)
                return new GenericCommandResult(false, "Caixa Eletronico não encontrado!", null);

            caixaEletronico.DesativarCaixa();

            this._caixaEletronicoRepository.Update(caixaEletronico);

            return new GenericCommandResult(true, "Caixa Eletronico desativado com sucesso", caixaEletronico);
        }
    }
}
