namespace Starter.Data.Configuration
{
    /// <summary>
    /// Defines the contract for the configuration settings
    /// </summary>
    public interface ISettings
    {
        string ConnectionString { get; }
    }
}