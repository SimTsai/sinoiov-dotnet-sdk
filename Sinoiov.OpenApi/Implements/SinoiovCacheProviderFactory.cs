using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using Sinoiov.OpenApi.Enums;
using Sinoiov.OpenApi.Interfaces;
using Sinoiov.OpenApi.Options;
using System;

namespace Sinoiov.OpenApi.Implements
{
    internal class SinoiovCacheProviderFactory : ISinoiovCacheProviderFactory
    {
        private readonly SinoiovOptions sinoiovOptions;

        public SinoiovCacheProviderFactory(
            IOptions<SinoiovOptions> sinoiovOptions
            )
        {
            this.sinoiovOptions = sinoiovOptions.Value;
        }

        public IDistributedCache GetProvider()
        {
            IDistributedCache distributedCache =
                sinoiovOptions.TokenStorageIn switch
                {
                    SinoiovTokenStorageType.InMemory => new MemoryDistributedCache(new OptionsWrapper<MemoryDistributedCacheOptions>(sinoiovOptions.InMemoryOptions ?? new MemoryDistributedCacheOptions())),
                    SinoiovTokenStorageType.Redis => new RedisCache(new OptionsWrapper<RedisCacheOptions>(sinoiovOptions.RedisOptions ?? new RedisCacheOptions())),
                    _ => throw new NotSupportedException()
                };
            return distributedCache;
        }
    }
}
