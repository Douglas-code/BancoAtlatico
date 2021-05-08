﻿using BancoAtlantico.Domain.Commands.Contracts;
using System.Threading.Tasks;

namespace BancoAtlantico.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
