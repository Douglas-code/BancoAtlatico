using BancoAtlantico.Domain.Entities;
using BancoAtlantico.Domain.Queries;
using BancoAtlantico.Domain.Repositories;
using BancoAtlantico.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtlantico.Infra.Repositories
{
    public class CaixaEletronicoRepository : ICaixaEletronicoRepository
    {
        private readonly DataContext _context;

        public CaixaEletronicoRepository(DataContext context)
        {
            this._context = context;
        }

        public List<CaixaEletronico> ListarCaixaEletronicosAtivos()
        {
            var list = this._context.CaixasEletronicos.Where(CaixaEletronicoQueries.BuscarCaixasAtivos()).AsNoTracking().ToList();
            return list;
        }

        public List<CaixaEletronico> ListarCaixasEletronicosDesativados()
        {
            var list = this._context.CaixasEletronicos.Where(CaixaEletronicoQueries.BuscarCaixasDesativados()).AsNoTracking().ToList();
            return list;
        }

        public List<CaixaEletronico> ListarTodos()
        {
            var list = this._context.CaixasEletronicos.AsNoTracking().ToList();
            return list;
        }

        public CaixaEletronico ObterCaixaEletronicoPorId(Guid Id)
        {
            var caixaEletronico = this._context.CaixasEletronicos.Where(x => x.Id == Id).FirstOrDefault();
            return caixaEletronico;
        }

        public void Save(CaixaEletronico caixaEletronico)
        {
            this._context.CaixasEletronicos.Add(caixaEletronico);
            this._context.SaveChanges();
        }

        public void Update(CaixaEletronico caixaEletronico)
        {
            this._context.Entry(caixaEletronico).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}
