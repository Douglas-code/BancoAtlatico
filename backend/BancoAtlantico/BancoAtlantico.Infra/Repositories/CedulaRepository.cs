using BancoAtlantico.Domain.Entities;
using BancoAtlantico.Domain.Repositories;
using BancoAtlantico.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtlantico.Infra.Repositories
{
    public class CedulaRepository : ICedulaRepository
    {
        private readonly DataContext _context;

        public CedulaRepository(DataContext context)
        {
            this._context = context;
        }

        public List<Cedula> ListarTodas()
        {
            var list = this._context.Cedulas.AsNoTracking().ToList();
            return list;
        }

        public Cedula ObterCedulaPorId(Guid Id)
        {
            var cedula = this._context.Cedulas.Where(x => x.Id == Id).FirstOrDefault();
            return cedula;
        }

        public void Save(Cedula cedula)
        {
            this._context.Add(cedula);
            this._context.SaveChanges();
        }

        public bool VerificarDuplicidade(Cedula cedula)
        {
            var cedulas = this._context.Cedulas.Where(x => x.Valor == cedula.Valor).Count();
            return cedulas > 0;
        }
    }
}
