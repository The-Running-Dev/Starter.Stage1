using System;
using System.IO;
using System.Reflection;
using Unity;
using Unity.Injection;
using Microsoft.Extensions.DependencyInjection;

using Starter.Repository;
using Starter.Data.Configuration;
using Starter.Data.Interfaces.Repositories;

namespace Starter.Bootstrapper
{
    /// <summary>
    /// Sets up the dependency resolution for the project
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Sets the dependency resolution for the web project
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceProvider Web(IServiceCollection services)
        {
            // Register all the dependencies
            Bootstrap();

            return IocWrapper.Instance.Container.Resolve<IServiceProvider>();
        }

        /// <summary>
        /// Provides means to registry different service implementations
        /// based on the setup type
        /// </summary>
        public static void Bootstrap()
        {
            var container = new UnityContainer();

            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dataFile = Path.Combine(assemblyDirectory, "Cats.json");

            container.RegisterType<ICatRepository, CatRepository>();
            container.RegisterType<ICatDataRepository, CatDataRepository>();
            container.RegisterType<ISettings, Settings>(new InjectionConstructor(dataFile));

            IocWrapper.Instance = new IocWrapper(container);
        }
    }
}