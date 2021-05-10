using BancoAtlantico.Domain.Commands;
using BancoAtlantico.Domain.Commands.Contracts;
using BancoAtlantico.Domain.Entities;
using BancoAtlantico.Domain.Handlers.Contracts;
using BancoAtlantico.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtlantico.Api.Controllers
{
    [Route("v1/cedulas")]
    [ApiController]
    public class CedulaController : ControllerBase
    {
        private readonly ICedulaRepository _repository;

        public CedulaController(ICedulaRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public List<Cedula> GetCedulas()
        {
            return this._repository.ListarTodas();
        }

        [HttpPost]
        public ICommandResult PostCedula([FromBody]CriarCedulaCommand command, [FromServices] IHandler<CriarCedulaCommand> handler)
        {
            return (GenericCommandResult)handler.Handle(command); 
        }
    }
}
