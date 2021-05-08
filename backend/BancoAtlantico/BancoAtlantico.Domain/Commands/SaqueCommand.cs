using BancoAtlantico.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace BancoAtlantico.Domain.Commands
{
    public class SaqueCommand : Notifiable, ICommand
    {
        public SaqueCommand() { }

        public SaqueCommand(Guid caixaEletronico, int valor)
        {
            CaixaEletronico = caixaEletronico;
            Valor = valor;
        }

        public Guid CaixaEletronico { get; set; }

        public int Valor { get; set; }

        public void Validate()
        {
            AddNotifications
            (
                new Contract()
                    .IsTrue(this.Valor > 0, "Valor", "O valor do saque deve ser maior que 0!")
                    .IsTrue(this.Valor <= 10000, "Valor", "O valor do saque deve ser menor ou igual que 10000!")
            );
        }
    }
}
