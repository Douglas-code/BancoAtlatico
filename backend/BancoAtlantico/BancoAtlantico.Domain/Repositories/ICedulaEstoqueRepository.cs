using BancoAtlantico.Domain.Entities;

namespace BancoAtlantico.Domain.Repositories
{
    public interface ICedulaEstoqueRepository
    {
        void Save(CedulaEstoque cedulaEstoque);

        void Update(CedulaEstoque cedula);
    }
}
