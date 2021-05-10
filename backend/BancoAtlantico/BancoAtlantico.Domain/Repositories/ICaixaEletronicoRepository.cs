using BancoAtlantico.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BancoAtlantico.Domain.Repositories
{
    public interface ICaixaEletronicoRepository
    {
        void Save(CaixaEletronico caixaEletronico);

        void Update(CaixaEletronico caixaEletronico);

        CaixaEletronico ObterCaixaEletronicoPorId(Guid Id);

        List<CaixaEletronico> ListarTodos();

        List<CaixaEletronico> ListarCaixasEletronicosDesativados();

        List<CaixaEletronico> ListarCaixaEletronicosAtivos();
    }
}
