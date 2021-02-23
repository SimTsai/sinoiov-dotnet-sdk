using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Sinoiov.OpenApi.Interfaces;
using Sinoiov.OpenApi.Options;

namespace Sinoiov.OpenApi.Implements
{
    internal class SinoiovTokenStorageService : ISinoiovTokenStorageService
    {
        private readonly IDistributedCache distributedCache;
        private readonly SinoiovOptions sinoiovOptions;

        public SinoiovTokenStorageService(
            ISinoiovCacheProviderFactory sinoiovCacheProviderFactory,
            IOptions<SinoiovOptions> sinoiovOptions
            )
        {
            distributedCache = sinoiovCacheProviderFactory.GetProvider();
            this.sinoiovOptions = sinoiovOptions?.Value;
        }

        public void Dispose()
        {
            if (distributedCache is not null && distributedCache is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        async public Task<string> LoadTokenAsync()
        {
            var token = await distributedCache
                 .GetStringAsync(this.sinoiovOptions.TokenKey)
                 .ConfigureAwait(false);
            return token;
        }

        async public Task SaveTokenAsync(string token)
        {
            await distributedCache
                .SetStringAsync(this.sinoiovOptions.TokenKey, token, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7) })
                .ConfigureAwait(false);
        }
    }
}
