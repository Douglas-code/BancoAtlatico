using BancoAtlantico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoAtlantico.Domain.Repositories
{
    public interface ICedulaRepository
    {
        void Save(Cedula cedula);

        Cedula ObterCedulaPorId(Guid Id);

        bool VerificarDuplicidade(Cedula cedula);

        List<Cedula> ListarTodas();
    }
}
