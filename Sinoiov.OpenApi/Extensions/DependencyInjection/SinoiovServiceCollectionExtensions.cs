using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinoiov.OpenApi.Implements;
using Sinoiov.OpenApi.Interfaces;
using Sinoiov.OpenApi.Options;

namespace Sinoiov.OpenApi.Extensions.DependencyInjection
{
    public static class SinoiovServiceCollectionExtensions
    {
        public static void AddSinoiov(this IServiceCollection services)
        {
            services.AddOptions();

            services.AddDistributedMemoryCache();
            services.AddStackExchangeRedisCache(o => { });
            services.AddTransient<ISinoiovCacheProviderFactory, SinoiovCacheProviderFactory>();
            services.AddTransient<ISinoiovTokenStorageService, SinoiovTokenStorageService>();
            services.AddTransient<ISinoiovSignService, SinoiovSignService>();
            services.AddHttpClient();
            services.AddTransient<ISinoiovHttpClient, SinoiovHttpClient>();
            services.AddTransient<ISinoiovOutRequestService, SinoiovOutRequestService>();
            services.AddTransient<ISinoiovLocationService, SinoiovLocationService>();
        }

        public static void AddSinoiov(this IServiceCollection services, Action<SinoiovOptions> setupAction)
        {
            services.AddSinoiov();
            services.ConfigSinoiov(setupAction);
        }

        public static void AddSinoiov(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.AddSinoiov();
            services.ConfigSinoiov(configurationSection);
        }

        public static void AddSinoiov(this IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            services.AddSinoiov();
            services.ConfigSinoiov(configurationRoot);
        }

        public static void ConfigSinoiov(this IServiceCollection services, Action<SinoiovOptions> setupAction)
        {
            services.Configure<SinoiovOptions>(setupAction);
        }

        public static void ConfigSinoiov(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<SinoiovOptions>(configurationSection);
        }

        public static void ConfigSinoiov(this IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            services.ConfigSinoiov(configurationRoot.GetSection(SinoiovOptions.DefaultOptionsName));
        }
    }
}
