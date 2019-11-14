using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using Starter.Data.Entities;
using Starter.Data.Configuration;
using Starter.Data.Interfaces.Repositories;

namespace Starter.Repository
{
    /// <summary>
    /// Implements loading and saving data to a JSON file
    /// </summary>
    public class CatDataRepository : ICatDataRepository
    {
        public CatDataRepository(ISettings settings)
        {
            _settings = settings ?? throw new ArgumentException(nameof(Settings));
            _entities = new List<Cat>();
        }

        /// <summary>
        /// Loads the cat entities from a JSON file
        /// </summary>
        /// <param name="reload">Should all data be reloaded</param>
        /// <returns></returns>
        public async Task<IEnumerable<Cat>> LoadAsync(bool reload = false)
        {
            if (_entities.Any() && !reload)
            {
                return _entities;
            }

            try
            {
                string jsonData;

                using (var reader = File.OpenText(_settings.ConnectionString))
                {
                    jsonData = await reader.ReadToEndAsync();
                }

                _entities = JsonConvert.DeserializeObject<List<Cat>>(jsonData).ToList();
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (JsonReaderException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadAsync Failed. {_settings.ConnectionString}. {ex.Message}");

                throw;
            }

            return _entities;
        }

        /// <summary>
        /// Saves the cat entities to a JSON file
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task SaveAsync(IEnumerable<Cat> entities)
        {
            try
            {
                var data = JsonConvert.SerializeObject(entities);

                using (var reader = File.CreateText(_settings.ConnectionString))
                {
                    await reader.WriteAsync(data);
                }
            }
            catch (IOException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Serialize to JSON Failed. {_settings.ConnectionString}. {ex.Message}");
                
                throw;
            }

            await LoadAsync(true);
        }

        private readonly ISettings _settings;

        private IEnumerable<Cat> _entities;
    }
}