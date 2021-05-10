using BancoAtlantico.Domain.Entities;
using BancoAtlantico.Domain.Repositories;
using BancoAtlantico.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BancoAtlantico.Infra.Repositories
{
    public class CedulaEstoqueRepository : ICedulaEstoqueRepository
    {
        private readonly DataContext _context;

        public CedulaEstoqueRepository(DataContext context)
        {
            this._context = context;
        }

        public void Save(CedulaEstoque cedulaEstoque)
        {
            this._context.Add(cedulaEstoque);
            this._context.SaveChanges();
        }

        public void Update(CedulaEstoque cedula)
        {
            this._context.Entry(cedula).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}
