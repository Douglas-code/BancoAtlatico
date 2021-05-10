using Flunt.Notifications;
using System;

namespace BancoAtlantico.Domain.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            
        }

        public Guid Id { get; protected set; }
    }
}
