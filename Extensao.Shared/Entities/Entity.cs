using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;

namespace Extensao.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
    }
}
