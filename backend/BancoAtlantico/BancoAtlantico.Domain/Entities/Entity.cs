using Flunt.Notifications;
using System;

namespace BancoAtlantico.Domain.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            this.Id = new Guid();
        }

        public Guid Id { get; private set; }
    }
}
