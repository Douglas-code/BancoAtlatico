using BancoAtlantico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoAtlantico.Domain.Repositories
{
    public interface ICaixaEletronicoRepository
    {
        void Save(CaixaEletronico caixaEletronico);

        Task<CaixaEletronico> ObterCaixaEletronicoPorId(Guid Id);

        Task<List<CaixaEletronico>> ListarTodos();
    }
}
