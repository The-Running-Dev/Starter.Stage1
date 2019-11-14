using System;

using Starter.Data.Interfaces;

namespace Starter.Data.Entities
{
    /// <summary>
    /// Implements a generic entity
    /// </summary>
    public class Entity: IEntity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.Empty;
        }
    }
}
