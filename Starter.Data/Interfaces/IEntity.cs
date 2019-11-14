using System;

namespace Starter.Data.Interfaces
{
    /// <summary>
    /// Defines the contract for a generic entity
    /// </summary>
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}