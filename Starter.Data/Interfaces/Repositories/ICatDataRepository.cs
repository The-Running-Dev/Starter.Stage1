using Starter.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Starter.Data.Interfaces.Repositories
{
    /// <summary>
    /// Defines the contract for loading and saving cat data
    /// </summary>
    public interface ICatDataRepository
    {
        /// <summary>
        /// Loads the data into entities
        /// </summary>
        /// <param name="reload">Should all data be reloaded</param>
        /// <returns></returns>
        Task<IEnumerable<Cat>> LoadAsync(bool reload = false);

        /// <summary>
        /// Saves the entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task SaveAsync(IEnumerable<Cat> entities);
    }
}