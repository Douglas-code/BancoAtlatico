using BancoAtlantico.Domain.Commands;
using BancoAtlantico.Domain.Commands.Contracts;
using BancoAtlantico.Domain.Entities;
using BancoAtlantico.Domain.Handlers.Contracts;
using BancoAtlantico.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BancoAtlantico.Api.Controllers
{
    [Route("v1/caixa-eletronico")]
    [ApiController]
    public class CaixaEletronicoController : ControllerBase
    {
        private readonly ICaixaEletronicoRepository _repository;

        public CaixaEletronicoController(ICaixaEletronicoRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public List<CaixaEletronico> GetTodos()
        {
            return this._repository.ListarTodos();
        }

        [HttpGet]
        [Route("ativos")]
        public List<CaixaEletronico> GetTodosAtivos()
        {
            return this._repository.ListarCaixaEletronicosAtivos();
        }

        [HttpGet]
        [Route("desativados")]
        public List<CaixaEletronico> GetTodosDestivados()
        {
            return this._repository.ListarCaixasEletronicosDesativados();
        }

        [HttpPost]
        public ICommandResult PostCaixaEletronico([FromBody] CriarCaixaEletronicoCommand command, [FromServices] IHandler<CriarCaixaEletronicoCommand> handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("desativar-caixa")]
        public ICommandResult PutDesativarCaixa([FromBody] DesativarCaixaEletronicoCommand command, [FromServices] IHandler<DesativarCaixaEletronicoCommand> handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("efetuar-saque")]
        public ICommandResult PutEfetuarSaque([FromBody] SaqueCommand command, [FromServices] IHandler<SaqueCommand> handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
