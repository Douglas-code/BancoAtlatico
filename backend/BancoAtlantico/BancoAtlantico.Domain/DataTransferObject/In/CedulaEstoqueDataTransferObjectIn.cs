using System;

namespace BancoAtlantico.Domain.DataTransferObject.In
{
    public class CedulaEstoqueDataTransferObjectIn
    {
        public Guid IdCedula { get; set; }

        public int Quantidade { get; set; }
    }
}
