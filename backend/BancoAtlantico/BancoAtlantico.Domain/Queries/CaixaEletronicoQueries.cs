using BancoAtlantico.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace BancoAtlantico.Domain.Queries
{
    public static class CaixaEletronicoQueries
    {
        public static Expression<Func<CaixaEletronico, bool>> BuscarCaixasAtivos()
        {
            return x => x.Status == Enums.ECaixaStatus.Ativo;
        }

        public static Expression<Func<CaixaEletronico, bool>> BuscarCaixasDesativados()
        {
            return x => x.Status == Enums.ECaixaStatus.Desativado;
        }
    }
}
