using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinoiov.OpenApi.Implements;
using Sinoiov.OpenApi.Interfaces;
using Sinoiov.OpenApi.Options;

namespace Sinoiov.OpenApi.Extensions.DependencyInjection
{
    /// <summary>
    /// 中交兴路 依赖注入
    /// </summary>
    public static class SinoiovServiceCollectionExtensions
    {
        /// <summary>
        /// 注入中交兴路服务
        /// </summary>
        /// <param name="services"></param>
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
            services.AddTransient<ISinoiovTokenService, SinoiovOutRequestService>();
        }

        /// <summary>
        /// 注入中交兴路服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        public static void AddSinoiov(this IServiceCollection services, Action<SinoiovOptions> setupAction)
        {
            services.AddSinoiov();
            services.ConfigSinoiov(setupAction);
        }

        /// <summary>
        /// 注入中交兴路服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationSection"></param>
        public static void AddSinoiov(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.AddSinoiov();
            services.ConfigSinoiov(configurationSection);
        }

        /// <summary>
        /// 注入中交兴路服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationRoot"></param>
        public static void AddSinoiov(this IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            services.AddSinoiov();
            services.ConfigSinoiov(configurationRoot);
        }

        /// <summary>
        /// 配置中交兴路服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        public static void ConfigSinoiov(this IServiceCollection services, Action<SinoiovOptions> setupAction)
        {
            services.Configure<SinoiovOptions>(setupAction);
        }

        /// <summary>
        /// 配置中交兴路服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationSection"></param>
        public static void ConfigSinoiov(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<SinoiovOptions>(configurationSection);
        }

        /// <summary>
        /// 配置中交兴路服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationRoot"></param>
        public static void ConfigSinoiov(this IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            services.ConfigSinoiov(configurationRoot.GetSection(SinoiovOptions.DefaultOptionsName));
        }
    }
}
