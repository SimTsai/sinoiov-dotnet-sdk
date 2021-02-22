using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinoiov.OpenApi.Extensions.DependencyInjection;
using Sinoiov.OpenApi.Options;
using System;

namespace Sinoiov.OpenApi.Tests.TestBase
{
    public class DITestBase
    {
        private readonly IServiceCollection Services;
        private static IServiceProvider RootServiceProvider;
        protected readonly Lazy<IServiceProvider> ServiceProvider;
        private readonly IConfigurationRoot Configuration;

        public DITestBase()
        {
            Services = new ServiceCollection();

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");

            configurationBuilder.AddUserSecrets(this.GetType().Assembly);
            Configuration = configurationBuilder.Build();

            ConfigureServices();
            ServiceProvider = new Lazy<IServiceProvider>(() => (RootServiceProvider ??= Services.BuildServiceProvider()).CreateScope().ServiceProvider);


            Services.AddSingleton<IConfigurationRoot>(Configuration);

        }

        private void ConfigureServices()
        {
            Services.AddSinoiov(Configuration.GetSection(SinoiovOptions.DefaultOptionsName));
        }
    }
}
