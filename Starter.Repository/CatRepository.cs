using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Starter.Data.Entities;
using Starter.Data.Interfaces.Repositories;

namespace Starter.Repository
{
    /// <summary>
    /// Implements cat CRUD operation
    /// </summary>w
    public class CatRepository : ICatRepository
    {
        public CatRepository(ICatDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
            _entities = new List<Cat>();
        }

        public async Task<IEnumerable<Cat>> GetAllAsync()
        {
            var entities = await _dataRepository.LoadAsync();

            return entities.AsEnumerable();
        }

        public async Task<Cat> GetByIdAsync(Guid id)
        {
            var entities = await _dataRepository.LoadAsync();

            return entities.FirstOrDefault(x => x.Id == id);
        }

        public async Task AddAsync(Cat entity)
        {
            var result = await _dataRepository.LoadAsync();
            var entities = result.ToList();

            entity.Id = Guid.NewGuid();

            entities.Add(entity);

            await _dataRepository.SaveAsync(entities);
        }

        public async Task UpdateAsync(Cat entity)
        {
            var existingEntity = await GetByIdAsync(entity.Id);

            if (existingEntity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            _entities.Remove(existingEntity);
            _entities.Add(entity);

            await _dataRepository.SaveAsync(_entities);
        }

        public async Task DeleteAsync(Cat entity)
        {
            var existingEntity = await GetByIdAsync(entity.Id);

            if (existingEntity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            _entities.Remove(existingEntity);

            await _dataRepository.SaveAsync(_entities);
        }

        private readonly ICatDataRepository _dataRepository;

        private readonly List<Cat> _entities;
    }
}