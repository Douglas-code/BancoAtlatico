using BancoAtlantico.Domain.Commands;
using BancoAtlantico.Domain.Commands.Contracts;
using BancoAtlantico.Domain.Entities;
using BancoAtlantico.Domain.Handlers.Contracts;
using BancoAtlantico.Domain.Repositories;
using System.Threading.Tasks;

namespace BancoAtlantico.Domain.Handlers
{
    public class CriarCaixaEletronicoCommandHandler : IHandler<CriarCaixaEletronicoCommand>
    {

        private readonly ICaixaEletronicoRepository _caixaEletronicoRepository;
        private readonly ICedulaRepository _cedulaRepository;
        private readonly ICedulaEstoqueRepository _cedulaEstoqueRepository;

        public CriarCaixaEletronicoCommandHandler(ICaixaEletronicoRepository caixaEletronicoRepository, 
            ICedulaRepository cedulaRepository, ICedulaEstoqueRepository cedulaEstoqueRepository)
        {
            this._caixaEletronicoRepository = caixaEletronicoRepository;
            this._cedulaRepository = cedulaRepository;
            this._cedulaEstoqueRepository = cedulaEstoqueRepository;
        }

        public ICommandResult Handle(CriarCaixaEletronicoCommand command)
        {
            if (command.Cedulas.Count == 0)
                return new GenericCommandResult(false, "Falha ao criar caixa", null);

            Cedula cedula;
            CedulaEstoque cedulaEstoque;
            CaixaEletronico caixaEletronico = new CaixaEletronico();

            foreach (var cedulaAdicionar in command.Cedulas)
            {
                cedula = this._cedulaRepository.ObterCedulaPorId(cedulaAdicionar.IdCedula);
                cedulaEstoque = new CedulaEstoque(cedula, cedulaAdicionar.Quantidade, caixaEletronico);
                caixaEletronico.AdicionarNovaCedula(cedulaEstoque);
                this._cedulaEstoqueRepository.Save(cedulaEstoque);
            }

            this._caixaEletronicoRepository.Save(caixaEletronico);
            
            return new GenericCommandResult(true, "Caixa criado com Sucesso", caixaEletronico);
        }
    }
}
