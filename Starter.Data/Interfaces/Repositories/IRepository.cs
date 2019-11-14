using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Starter.Data.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for providing CRUD operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}