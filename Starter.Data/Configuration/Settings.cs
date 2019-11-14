using System.Configuration;

namespace Starter.Data.Configuration
{
    /// <summary>
    /// Implements the configuration settings interface
    /// </summary>
    public class Settings : ISettings
    {
        public Settings(string connectionString)
        {
            //var name = ConfigurationManager.AppSettings.Get("ConnectionName");
            //ConnectionString = ConfigurationManager.ConnectionStrings[$"ConnectionStrings.{name}"].ConnectionString;
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}
