using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Sinoiov.OpenApi.Interfaces;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class ISinoiovCacheProviderFactoryTests : TestBase.DITestBase
    {
        private readonly ISinoiovCacheProviderFactory sinoiovCacheProviderFactory;

        public ISinoiovCacheProviderFactoryTests()
        {
            sinoiovCacheProviderFactory = ServiceProvider.Value.GetRequiredService<ISinoiovCacheProviderFactory>();
        }

        [Fact]
        async public Task GetProviderTest()
        {
            var distributedCache = sinoiovCacheProviderFactory.GetProvider();
            Assert.NotNull(distributedCache);

            await distributedCache
                .SetStringAsync("Sinoiov:OpenApi:Tests:ISinoiovCacheProviderFactoryTest:GetProviderTest", Guid.NewGuid().ToString("N"), new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3) })
                .ConfigureAwait(false);
            var value = await distributedCache
                .GetStringAsync("Sinoiov:OpenApi:Tests:ISinoiovCacheProviderFactoryTest:GetProviderTest")
                .ConfigureAwait(false);

        }
    }
}
